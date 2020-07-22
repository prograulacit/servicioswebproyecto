const divDeContenido = document.getElementById("contenido");

function boton_consultar() {
    // Capturamos lo que el usuario ha escogido del dropdown.
    var dropdown = document.getElementById("dropdown_consulta");
    var seleccion = dropdown.options[dropdown.selectedIndex].text;

    switch (seleccion) {
        case "Bitacora":
            traer_bitacoras();
            break;
        case "Errores":
            traer_errores();
            break;
        case "Transacciones":
            traer_transacciones();
            break;
        case "Descargas":
            traer_descargas();
            break;
        default:
            traer_bitacoras();
            break;
    }
}

function traer_bitacoras() {
    const url = "https://localhost:44371/api/bitacora";

    fetch(url)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let json = JSON.parse(response);
            //renderizar_categorias_libros(json, contenedor_id);
            if (json != null) {

                let html = "";

                html +=
                    `<p>Total de datos: ${json.length}</p>
                    <p>Registros: <br>
                    `;
                for (let index = 0; index < json.length; index++) {
                    html += json[index].id + "<br>" + json[index].categoria + "<br><br>";
                }
                html += "</p>";

                document.getElementById("contenido").innerHTML = "** Cargando datos...";
                document.getElementById("contenido").innerHTML = html;
            } else {
                document.getElementById("contenido").innerHTML = "No hay registros de bitacora.";
            }
        })
        .catch(function (err) {
            console.error(err);
            document.getElementById("contenido").innerHTML = "*** Ha ocurrido un error";
        });
}

function traer_errores() {

}

function traer_transacciones() {

}

function traer_descargas() {

}