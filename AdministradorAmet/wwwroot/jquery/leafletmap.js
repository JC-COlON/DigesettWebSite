export async function load_map(rango) {
    console.log("Rango recibido:", rango);

    // 🧹 Eliminar el mapa anterior si ya fue creado
    if (window._leaflet_map_instance) {
        window._leaflet_map_instance.remove();
        window._leaflet_map_instance = null;
    }

    const map = L.map('map', {
        center: [18.7357, -70.1627],
        zoom: 8,
        scrollWheelZoom: false,
        doubleClickZoom: false,
        zoomControl: false
    });

    // 💾 Guardar la instancia del mapa globalmente
    window._leaflet_map_instance = map;

    const bounds = [
        [17.5, -71.5],
        [22.0, -68.8]
    ];
    map.setMaxBounds(bounds);

    L.tileLayer('https://api.mapbox.com/styles/v1/jrcolon/cmapu8xqq01cd01s8ensn822v/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoianJjb2xvbiIsImEiOiJjbWFuZzE0eGEwdmQwMnhvam5ocXNhbjZsIn0.tSPQn8MwpX9PrzpMP3Xv3g', {
        tileSize: 512,
        zoomOffset: -1,
        attribution: '© <a href="https://www.mapbox.com/about/maps/">Mapbox</a> © <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
        maxZoom: 18,
    }).addTo(map);

    function getColor(multas) {
        multas = Number(multas) || 0;
        return multas > 10 ? '#800026' :
            multas > 8 ? '#BD0026' :
                multas > 6 ? '#E31A1C' :
                    multas > 4 ? '#FC4E2A' :
                        multas > 2 ? '#FD8D3C' :
                            multas > 0 ? '#FEB24C' :
                                '#FFEDA0';
    }

    function style(feature) {
        const multas = feature.properties.multas || 0;
        return {
            fillColor: getColor(multas),
            weight: 2,
            opacity: 1,
            color: 'white',
            dashArray: '3',
            fillOpacity: 0.7
        };
    }

    try {
        const geoResponse = await fetch('/data/geojson.json');
        const geoJson = await geoResponse.json();

        const multasResponse = await fetch(`https://digesett.somee.com/api/Ticket/api/zona-multas/resumen?rango=${rango}`);

        if (!multasResponse.ok) {
            const errorText = await multasResponse.text();
            throw new Error(`Error en API: ${multasResponse.status} - ${errorText}`);
        }

        const contentType = multasResponse.headers.get("content-type");
        if (!contentType || !contentType.includes("application/json")) {
            const errorText = await multasResponse.text();
            throw new Error(`Respuesta no JSON: ${errorText}`);
        }

        const multasPorZona = await multasResponse.json();

        geoJson.features.forEach(feature => {
            const zonaNombre = feature.properties.name;
            const cantidad = multasPorZona[zonaNombre] || 0;
            feature.properties.multas = cantidad;
        });

        L.geoJson(geoJson, {
            style: style,
            onEachFeature: function (feature, layer) {
                const nombre = feature.properties.name;
                const multas = feature.properties.multas;
                layer.bindPopup(`<strong>${nombre}</strong><br>Multas: ${multas}`);
            }
        }).addTo(map);

    } catch (error) {
        console.error("Error al cargar el mapa:", error.message);
        alert("No se pudieron cargar los datos del mapa: " + error.message);
    }

    return "";
}
