const url = "https://localhost:44371/api/pelicula";

function eliminar_elemento(id) {
    Swal.fire({
        title: 'Esta seguro que desea eliminar este elemento?',
        text: "Esta accion no se puede deshacer",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText: "Cancelar"
    }).then((result) => {
        if (result.value) {

            if (id != "") {
                var json_request = {
                    ID: id
                };

                fetch(url + '/?ID=' + id, {
                    method: 'delete'
                }).then(response =>
                    response.json().then((json) => {
                        console.log(json);
                        Swal.fire(
                            'Hecho',
                            'El elemento ha sido eliminado con exito.',
                            'success'
                        ).then((result) => {
                            if (result.value) {
                                location.reload();
                            }
                        })
                    })
                );
            }
        }
    })
}

function crear_elemento() {

    const crear_nombre = document.getElementById("crear_nombre").value
    const crear_genero = document.getElementById("crear_genero").value
    const crear_anio = document.getElementById("crear_anio").value
    const crear_idioma = document.getElementById("crear_idioma").value
    const crear_actores = document.getElementById("crear_actores").value
    const crear_descarga = document.getElementById("crear_descarga").value
    const crear_previsualizacion = document.getElementById("crear_previsualizacion").value
    const crear_monto = document.getElementById("crear_monto").value

    if (crear_nombre != "" &&
        crear_genero != "" &&
        crear_anio != "" &&
        crear_idioma != "" &&
        crear_actores != "" &&
        crear_descarga != "" &&
        crear_previsualizacion != "" &&
        crear_monto != "") {

        var json_request = {
            "nombre": crear_nombre,
            "genero": crear_genero,
            "anio": crear_anio,
            "idioma": crear_idioma,
            "actores": crear_actores,
            "nombreArchivoDescarga": crear_descarga,
            "nombreArchivoPrevisualizacion": crear_previsualizacion,
            "monto": crear_monto
        };

        fetch(url, {
            method: 'POST',
            body: JSON.stringify(json_request), // data can be `string` or {object}!
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .catch(error => console.error('Error:', error))
            .then((response) => {
                console.log('Success:', response)

                document.getElementById("crear_nombre").value = ""
                document.getElementById("crear_genero").value = ""
                document.getElementById("crear_anio").value = ""
                document.getElementById("crear_idioma").value = ""
                document.getElementById("crear_actores").value = ""
                document.getElementById("crear_descarga").value = ""
                document.getElementById("crear_previsualizacion").value = ""
                document.getElementById("crear_monto").value = ""

                cargar_elementos();
            });
    } else {
        errorLlenarEspacios();
    }
}

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
                                <th scope="col">ID</th>
                                <th scope="col">Nombre</th>
                                <th scope="col">Genero</th>
                                <th scope="col">Año</th>
                                <th scope="col">Idioma</th>
                                <th scope="col">Actores</th>
                                <th scope="col">Archivo Descarga</th>
                                <th scope="col">Archivo Previsualizacion</th>
                                <th scope="col">Monto</th>
                            </tr>
                        `;

        for (let index = 0; index < obj.length; index++) {
            contenidoHtml +=
                `<tr>
                                <td>` + obj[index].id + `</td>
                                <td>` + obj[index].nombre + `</td>
                                <td>` + obj[index].genero + `</td>
                                <td>` + obj[index].anio + `</td>
                                <td>` + obj[index].idioma + `</td>
                                <td>` + obj[index].actores + `</td>
                                <td>` + obj[index].nombreArchivoDescarga + `</td>
                                <td>` + obj[index].nombreArchivoPrevisualizacion + `</td>
                                <td>` + obj[index].monto + `</td>
                                <td> <a href="#" onclick="editar_elemento('` + obj[index].id + `')">Editar</a> </td>
                                <td> <a href="#" onclick="eliminar_elemento('${obj[index].id}')">Eliminar</a> </td>
                            </tr>
                            `
        }
        contenidoHtml +=
            `
                        </table>
                        `;

        contenedorTabla_visible("inline")
        contenedorCrear_visible("none")
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
                    document.getElementById("editar_id").value = json[index].id;
                    document.getElementById("editar_nombre").value = json[index].nombre;
                    document.getElementById("editar_genero").value = json[index].genero;
                    document.getElementById("editar_anio").value = json[index].anio;
                    document.getElementById("editar_idioma").value = json[index].idioma;
                    document.getElementById("editar_actores").value = json[index].actores;
                    document.getElementById("editar_descarga").value = json[index].nombreArchivoDescarga;
                    document.getElementById("editar_previsualizacion").value = json[index].nombreArchivoPrevisualizacion;
                    document.getElementById("editar_monto").value = json[index].monto;
                }
            }

        })
        .catch(function (err) {
            console.error(err);
        });
}

function guardar_cambios() {
    const editar_id = document.getElementById("editar_id").value;
    const editar_nombre = document.getElementById("editar_nombre").value
    const editar_genero = document.getElementById("editar_genero").value
    const editar_anio = document.getElementById("editar_anio").value
    const editar_idioma = document.getElementById("editar_idioma").value
    const editar_actores = document.getElementById("editar_actores").value
    const editar_descarga = document.getElementById("editar_descarga").value
    const editar_previsualizacion = document.getElementById("editar_previsualizacion").value
    const editar_monto = document.getElementById("editar_monto").value

    if (editar_id != "" &&
        editar_nombre != "" &&
        editar_genero != "" &&
        editar_anio != "" &&
        editar_idioma != "" &&
        editar_actores != "" &&
        editar_descarga != "" &&
        editar_previsualizacion != "" &&
        editar_monto != "") {

        var json_request = {
            "ID": editar_id,
            "nombre": editar_nombre,
            "genero": editar_genero,
            "anio": editar_anio,
            "idioma": editar_idioma,
            "actores": editar_actores,
            "nombreArchivoDescarga": editar_descarga,
            "nombreArchivoPrevisualizacion": editar_previsualizacion,
            "monto": editar_monto
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
                cargar_elementos();
                contenedorTabla_visible("inline");
                contenedorEditar_visible("none");
                contenedorCrear_visible("none");
            });

    } else {
        errorLlenarEspacios();
    }

}

function contenedorEditar_visible(status) {
    document.getElementById("contenedor_editar").style.display = status;
}

function contenedorCrear_visible(status) {
    document.getElementById("contenedor_crear").style.display = status;
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