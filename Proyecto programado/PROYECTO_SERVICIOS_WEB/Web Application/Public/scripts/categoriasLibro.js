// URL de la API.
const url = "https://localhost:44371/api/categorias_libros";

// GET
function obtener_elementos() {

    const contenedor_id = "http_response_contenido";

    fetch(url)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let json = JSON.parse(response);
            renderizar(json, contenedor_id);
        })
        .catch(function (err) {
            console.error(err);
            document.getElementById(contenedor_id).innerHTML = "*** Ha ocurrido un error ***";
        });
}

function renderizar(json, contenedor_id) {
    if (json != null) {

        let contenidoHtml = "";

        let obj = voltearValoresObj(json);

        contenidoHtml +=
            `<p>Total de registros: ${obj.length}</p>
                        <table class="table table-striped">
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Categoria</th>
                            </tr>
                        `;

        for (let index = 0; index < obj.length; index++) {
            contenidoHtml +=
                `<tr>
                                <td>` + obj[index].id + `</td>
                                <td>` + obj[index].categoria + `</td>
                            </tr>
                            `
        }
        contenidoHtml +=
            `
                        </table>
                        `;

        document.getElementById(contenedor_id).innerHTML = "** Cargando datos...";
        document.getElementById(contenedor_id).innerHTML = contenidoHtml;
    } else {
        document.getElementById(contenedor_id).innerHTML = "No hay registros guardados.";
    }
}

// POST
function ingresar_elemento() {
    const contenido = document.getElementById("input_elementoNuevo").value;

    if (contenido != "") {

        var json_request = {
            categoria: contenido
        };

        fetch(url, {
            method: 'POST',
            body: JSON.stringify(json_request),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .catch(error => console.error('Error:', error))
            .then((response) => {
                document.getElementById("input_elementoNuevo").value = "";
                console.log('Success:', response)
                obtener_elementos();
            });
    } else {
        console.log('Espacios vacios.');
        error_espaciosVacios();
    }
}

// UPDATE
function actualizar_elemento() {

    const id = document.getElementById("inputId_elementoActualizar").value;
    const contenido = document.getElementById("inputContenido_elementoActualizar").value;

    if (id != "" && contenido != "") {
        var json_request = {
            ID: id,
            categoria: contenido
        };

        fetch(url, {
            method: 'PUT',
            body: JSON.stringify(json_request), // data can be `string` or {object}!
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .catch(error => console.error('Error:', error))
            .then((response) => {
                console.log('Success:', response)
                document.getElementById("inputId_elementoActualizar").value = "";
                document.getElementById("inputContenido_elementoActualizar").value = "";
                obtener_elementos();
            });
    } else {
        error_espaciosVacios();
    }
}

// DELETE
function eliminar_elemento() {
    const id = document.getElementById("inputId_elementoEliminar").value;

    if (id != "") {
        var json_request = {
            ID: id
        };

        fetch(url + '/?ID=' + id, {
            method: 'delete'
        }).then(response =>
            response.json().then((json) => {
                console.log(json);
                document.getElementById("inputId_elementoEliminar").value = "";
                obtener_elementos();
            })
        );
    } else {
        error_espaciosVacios();
    }
}

function error_espaciosVacios() {
    Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Por favor, rellene los espacios requeridos',
    })
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