export function load_map() {
    const map = L.map('map', {
        center: [18.7357, -70.1627],  // Centrado en la RD
        zoom: 8,  // Nivel de zoom inicial
        scrollWheelZoom: false,  // Desactiva el zoom con la rueda del mouse
        doubleClickZoom: false   // Desactiva el zoom con doble clic
    });

    // Límite de la República Dominicana, desplazado un poco más a la derecha
    const bounds = [
        [17.5, -71.5],  // Suroeste (aproximado)
        [22.0, -68.8]   // Noreste (aproximado), movido más a la derecha
    ];


    map.setMaxBounds(bounds);

    // Agregar la capa base de Mapbox con tu Access Token
    L.tileLayer('https://api.mapbox.com/styles/v1/jrcolon/cmanh2hcn000z01qpbw5ha93z/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoianJjb2xvbiIsImEiOiJjbWFuZzE0eGEwdmQwMnhvam5ocXNhbjZsIn0.tSPQn8MwpX9PrzpMP3Xv3g', {
        tileSize: 512,
        zoomOffset: -1,
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, ' +
            'Imagery © <a href="https://www.mapbox.com">Mapbox</a>'
    }).addTo(map);


    return "";
}
