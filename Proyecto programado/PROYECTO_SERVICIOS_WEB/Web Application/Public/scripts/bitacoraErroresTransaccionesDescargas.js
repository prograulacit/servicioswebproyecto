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

// Este metodo se encarga de dar vuelta a los valores del array
// de tal forma que los valores más nuevos son mostrados de
// primero.
function voltearValoresObj(objResponse) {
    let objResponseLength = objResponse.length - 1;
    let objNew = {};

    for (let index = 0; index < objResponse.length; index++) {
        objNew[index] = objResponse[objResponseLength];
        objResponseLength--;
    }
    // Le damos la propiedad length y le asignamos la length actual.
    objNew.length = objResponse.length;
    return objNew;
}

function traer_bitacoras() {

    const APIUrl = "https://localhost:44371/api/bitacora";

    fetch(APIUrl)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let objResponse = JSON.parse(response);
            if (objResponse != null) {

                let contenidoHtml = "";

                let objBitacoras = voltearValoresObj(objResponse);

                contenidoHtml +=
                    `<p>Total de registros: ${objBitacoras.length}</p>
                    <p>Registros:</p> <br>
                    <table class="table table-striped">
                            <tr>
                                <th scope="col">Codigo del registro</th>    
                                <th scope="col">Admin</th>
                                <th scope="col">Fecha y hora</th>
                                <th scope="col">Tipo</th>
                                <th scope="col">Descripcion</th>
                                <th scope="col">Registro en detalle</th>
                            </tr>
                    `;
                for (let index = 0; index < objBitacoras.length; index++) {

                    contenidoHtml += `<tr>
                                <td>` + objBitacoras[index].id + `</td>            
                                <td>` + objBitacoras[index].nombreUsuarioAdmin + `</td>
                                <td>` + objBitacoras[index].fechaYHora + `</td>
                                <td>` + objBitacoras[index].tipo + `</td>
                                <td>` + objBitacoras[index].descripcion + `</td>
                                <td>` + objBitacoras[index].registroEnDetalle + `</td>
                            </tr>
                            `
                }
                contenidoHtml += "</table>";
                document.getElementById("contenido").innerHTML = contenidoHtml;

            } else {
                document.getElementById("contenido").innerHTML = "No hay registros de bitacora.";
            }
        })
        .catch(function (err) {
            console.error(err);
            document.getElementById("contenido").innerHTML = "*** Ha ocurrido un error ***";
        });
}

function traer_errores() {
    const APIUrl = "https://localhost:44371/api/error";

    fetch(APIUrl)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let objResponse = JSON.parse(response);
            if (objResponse != null) {

                let contenidoHtml = "";

                let objBitacoras = voltearValoresObj(objResponse);

                contenidoHtml +=
                    `<p>Total de registros: ${objBitacoras.length}</p>
                    <p>Registros:</p> <br>
                    <table class="table table-striped">
                            <tr>
                                <th scope="col">Num registro</th>    
                                <th scope="col">Admin</th>
                                <th scope="col">Fecha</th>
                                <th scope="col">Detalles del error</th>
                            </tr>
                    `;
                for (let index = 0; index < objBitacoras.length; index++) {

                    contenidoHtml += `<tr>
                                <td>` + objBitacoras[index].id + `</td>            
                                <td>` + objBitacoras[index].idUsuario + `</td>
                                <td>` + objBitacoras[index].fechaYHora + `</td>
                                <td>` + objBitacoras[index].mensajeDeError + `</td>
                            </tr>
                            `
                }
                contenidoHtml += "</table>";
                document.getElementById("contenido").innerHTML = contenidoHtml;

            } else {
                document.getElementById("contenido").innerHTML = "No hay registros de errores.";
            }
        })
        .catch(function (err) {
            console.error(err);
            document.getElementById("contenido").innerHTML = "*** Ha ocurrido un error ***";
        });
}

function traer_transacciones() {
    const APIUrl = "https://localhost:44371/api/transaccion";

    fetch(APIUrl)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let objResponse = JSON.parse(response);
            if (objResponse != null) {

                let contenidoHtml = "";

                let objBitacoras = voltearValoresObj(objResponse);

                contenidoHtml +=
                    `<p>Total de registros: ${objBitacoras.length}</p>
                    <p>Registros:</p> <br>
                    <table class="table table-striped">
                            <tr>
                                <th scope="col">Num registro</th>    
                                <th scope="col">Fecha</th>
                                <th scope="col">Monto</th>
                                <th scope="col">Monto</th>
                                <th scope="col">Detalles del error</th>
                            </tr>
                    `;
                for (let index = 0; index < objBitacoras.length; index++) {

                    contenidoHtml += `<tr>
                                <td>` + objBitacoras[index].id + `</td>            
                                <td>` + objBitacoras[index].idUsuario + `</td>
                                <td>` + objBitacoras[index].fechaYHora + `</td>
                                <td>` + objBitacoras[index].mensajeDeError + `</td>
                            </tr>
                            `
                }
                contenidoHtml += "</table>";
                document.getElementById("contenido").innerHTML = contenidoHtml;

            } else {
                document.getElementById("contenido").innerHTML = "No hay registros de transacciones.";
            }
        })
        .catch(function (err) {
            console.error(err);
            document.getElementById("contenido").innerHTML = "*** Ha ocurrido un error ***";
        });
}

function traer_descargas() {

}