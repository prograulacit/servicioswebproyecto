const url = "https://localhost:44371/api/consecutivo";

function cargar_elementos() {

    const contenedor_id = "contenedor_tabla";

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
                                <th scope="col">Codigo</th>
                                <th scope="col">Descripcion</th>
                                <th scope="col">Consecutivo</th>
                            </tr>
                        `;

        for (let index = 0; index < obj.length; index++) {
            contenidoHtml +=
                `<tr>
                                <td>` + obj[index].id + `</td>
                                <td>` + obj[index].tipoConsecutivo + `</td>
                                <td>` + obj[index].descripcion + `</td>
                                <td> <a href="#" onclick="editar_elemento('` + obj[index].id + `')">Editar</a> </td>
                            </tr>
                            `
        }
        contenidoHtml +=
            `
                        </table>
                        `;

        contenedorTabla_visible("inline")
        contenedorEditar_visible("none")

        document.getElementById(contenedor_id).innerHTML = "** Cargando datos...";
        document.getElementById(contenedor_id).innerHTML = contenidoHtml;
    } else {
        document.getElementById(contenedor_id).innerHTML = "No hay registros guardados.";
    }
}

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

function editar_elemento(codigo) {

    contenedorEditar_visible("inline");
    contenedorTabla_visible("none");

    fetch(url)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let json = JSON.parse(response);

            for (let index = 0; index < json.length; index++) {
                if (json[index].id == codigo) {
                    document.getElementsByClassName("editar_id")[0].value = json[index].id;
                    document.getElementsByClassName("editar_tipo")[0].value = json[index].tipoConsecutivo;
                    document.getElementsByClassName("editar_descripcion")[0].value = json[index].descripcion;
                    document.getElementsByClassName("editar_prefijo")[0].value = json[index].prefijo;
                    document.getElementsByClassName("editar_rangoInicial")[0].value = json[index].rangoInicial;
                    document.getElementsByClassName("editar_rangoFinal")[0].value = json[index].rangoFinal;
                }
            }
        })
        .catch(function (err) {
            console.error(err);
        });
}

function guardar_cambios() {
    const editar_id = document.getElementsByClassName("editar_id")[0].value
    const editar_tipo = document.getElementsByClassName("editar_tipo")[0].value
    const editar_descripcion = document.getElementsByClassName("editar_descripcion")[0].value
    const editar_prefijo = document.getElementsByClassName("editar_prefijo")[0].value
    const editar_rangoInicial = document.getElementsByClassName("editar_rangoInicial")[0].value
    const editar_rangoFinal = document.getElementsByClassName("editar_rangoFinal")[0].value

    if (editar_id != "" &&
        editar_tipo != "" &&
        editar_descripcion != "" &&
        editar_prefijo != "" &&
        editar_rangoInicial != "" &&
        editar_rangoFinal != "") {

        var json_request = {
            "id": editar_id,
            "tipoConsecutivo": editar_tipo,
            "descripcion": editar_descripcion,
            "prefijo": editar_prefijo,
            "rangoInicial": editar_rangoInicial,
            "rangoFinal": editar_rangoFinal,
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
                console.log("Success: " + response);
                cargar_elementos();
            });

    } else {
        errorLlenarEspacios();
    }

}

function contenedorEditar_visible(status) {
    document.getElementById("contenedor_editar").style.display = status;
}

function contenedorTabla_visible(status) {
    document.getElementById("contenedor_tabla").style.display = status;
}

function errorLlenarEspacios() {
    Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Por favor, rellene todos los espacios.',
    })
}
