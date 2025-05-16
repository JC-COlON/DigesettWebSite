export async function load_map() {
    const map = L.map('map', {
        center: [18.7357, -70.1627],
        zoom: 8,
        scrollWheelZoom: false,
        doubleClickZoom: false,
        zoomControl: false
    });

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
    }).addTo(map); // ojo, antes tenías mapa, debe ser 'map'

    // FUNCIONES DE COLOR Y ESTILO
    function getColor(multas) {
        multas = Number(multas) || 0;

        return multas > 10 ? '#800026' :
            multas > 8 ? '#BD0026' :
                multas > 6 ? '#E31A1C' :
                    multas > 4 ? '#FC4E2A' :
                        multas > 2 ? '#FD8D3C' :
                            multas > 0 ? '#FEB24C' :
                                '#FFEDA0'; // Sin multas
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

    const geoResponse = await fetch('/data/geojson.json');
    const geoJson = await geoResponse.json();

    const multasResponse = await fetch('https://localhost:7277/api/Ticket/api/zona-multas/resumen');
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

    return "";
}
