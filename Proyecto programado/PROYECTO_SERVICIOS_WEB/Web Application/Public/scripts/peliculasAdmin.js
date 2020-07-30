const url = "https://localhost:44371/api/pelicula";
regexExtensionPelicula = new RegExp("(.*?)\.(mp4|mov)$");

function eliminar_elemento(id, nombreArchivoDescarga, nombreArchivoPrevisualizacion) {
    const eliminar_archivo_pelicula = document.getElementsByClassName("eliminar_archivo_pelicula")[0];
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
                        document.getElementsByClassName("viejo_nombre_descarga_pelicula")[0].value = nombreArchivoDescarga;
                        document.getElementsByClassName("viejo_nombre_previsualizacion_pelicula")[0].value = nombreArchivoPrevisualizacion;
                        eliminar_archivo_pelicula.click();
                    })
                );
            }
        }
    })
}

function crear_elemento() {
    const descargar_archivo_pelicula = document.getElementsByClassName("descargar_archivo_pelicula")[0];
    const crear_nombre = document.getElementsByClassName("crear_nombre")[0].value
    const crear_genero = document.getElementsByClassName("crear_genero")[0].value
    const crear_anio = document.getElementsByClassName("crear_anio")[0].value
    const crear_idioma = document.getElementsByClassName("crear_idioma")[0].value
    const crear_actores = document.getElementsByClassName("crear_actores")[0].value
    const nombre_archivo_pelicula = document.getElementsByClassName("nombre_archivo_pelicula")[0].value
    const nombre_previsualizacion_pelicula = document.getElementsByClassName("nombre_previsualizacion_pelicula")[0].value
    const crear_monto = document.getElementsByClassName("crear_monto")[0].value
    const archivo_pelicula = document.getElementsByClassName("archivo_pelicula")[0].files
    const archivo_pelicula_prev = document.getElementsByClassName("archivo_pelicula_prev")[0].files

    if (crear_nombre != "" &&
        crear_genero != "" &&
        crear_anio != "" &&
        crear_idioma != "" &&
        crear_actores != "" &&
        nombre_archivo_pelicula != "" &&
        nombre_previsualizacion_pelicula != "" &&
        crear_monto != "" &&
        archivo_pelicula.length > 0 &&
        archivo_pelicula_prev.length > 0) {

        if (!regexExtensionPelicula.test(nombre_archivo_pelicula) || !regexExtensionPelicula.test(nombre_previsualizacion_pelicula)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de pelicula y previsualizacion deben tener extension MP4 o MOV',
            })
        } else if (nombre_archivo_pelicula === nombre_previsualizacion_pelicula) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de pelicula y previsualizacion no pueden tener el mismo nombre.',
            })
        } else {

            var json_request = {
                "nombre": crear_nombre,
                "genero": crear_genero,
                "anio": crear_anio,
                "idioma": crear_idioma,
                "actores": crear_actores,
                "nombreArchivoDescarga": nombre_archivo_pelicula,
                "nombreArchivoPrevisualizacion": nombre_previsualizacion_pelicula,
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
                    descargar_archivo_pelicula.click();
                });
        }
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
                                <td> <a href="#" onclick="eliminar_elemento('${obj[index].id}', '${obj[index].nombreArchivoDescarga}', '${obj[index].nombreArchivoPrevisualizacion}')">Eliminar</a> </td>
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
                    document.getElementsByClassName("editar_id")[0].value = json[index].id;
                    document.getElementsByClassName("editar_nombre")[0].value = json[index].nombre;
                    document.getElementsByClassName("editar_genero")[0].value = json[index].genero;
                    document.getElementsByClassName("editar_anio")[0].value = json[index].anio;
                    document.getElementsByClassName("editar_idioma")[0].value = json[index].idioma;
                    document.getElementsByClassName("editar_actores")[0].value = json[index].actores;
                    document.getElementsByClassName("editar_nombre_descarga_pelicula")[0].value = json[index].nombreArchivoDescarga;
                    document.getElementsByClassName("editar_nombre_previsualizacion_pelicula")[0].value = json[index].nombreArchivoPrevisualizacion;
                    document.getElementsByClassName("editar_monto")[0].value = json[index].monto;
                    document.getElementsByClassName("viejo_nombre_descarga_pelicula")[0].value = json[index].nombreArchivoDescarga;
                    document.getElementsByClassName("viejo_nombre_previsualizacion_pelicula")[0].value = json[index].nombreArchivoPrevisualizacion;
                }
            }

        })
        .catch(function (err) {
            console.error(err);
        });
}

function guardar_cambios() {
    const editar_archivos_pelicula = document.getElementsByClassName("editar_archivos_pelicula")[0];
    const editar_id = document.getElementsByClassName("editar_id")[0].value;
    const editar_nombre = document.getElementsByClassName("editar_nombre")[0].value
    const editar_genero = document.getElementsByClassName("editar_genero")[0].value
    const editar_anio = document.getElementsByClassName("editar_anio")[0].value
    const editar_idioma = document.getElementsByClassName("editar_idioma")[0].value
    const editar_actores = document.getElementsByClassName("editar_actores")[0].value
    const editar_nombre_descarga_pelicula = document.getElementsByClassName("editar_nombre_descarga_pelicula")[0].value
    const editar_nombre_previsualizacion_pelicula = document.getElementsByClassName("editar_nombre_previsualizacion_pelicula")[0].value
    const editar_monto = document.getElementsByClassName("editar_monto")[0].value

    if (editar_id != "" &&
        editar_nombre != "" &&
        editar_genero != "" &&
        editar_anio != "" &&
        editar_idioma != "" &&
        editar_actores != "" &&
        editar_nombre_descarga_pelicula != "" &&
        editar_nombre_previsualizacion_pelicula != "" &&
        editar_monto != "") {

        var json_request = {
            "ID": editar_id,
            "nombre": editar_nombre,
            "genero": editar_genero,
            "anio": editar_anio,
            "idioma": editar_idioma,
            "actores": editar_actores,
            "nombreArchivoDescarga": editar_nombre_descarga_pelicula,
            "nombreArchivoPrevisualizacion": editar_nombre_previsualizacion_pelicula,
            "monto": editar_monto
        };

        if (!regexExtensionPelicula.test(editar_nombre_descarga_pelicula) || !regexExtensionPelicula.test(editar_nombre_previsualizacion_pelicula)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de pelicula y previsualizacion deben tener extension MP3 o MOV',
            })
        } else if (editar_nombre_descarga_pelicula === editar_nombre_previsualizacion_pelicula) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de pelicula y previsualizacion no pueden tener el mismo nombre.',
            })
        } else {
            fetch(url, {
                method: 'PUT',
                body: JSON.stringify(json_request), // data can be `string` or {object}!
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(res => res.json())
                .catch(error => console.error('Error:', error))
                .then((response) => {
                    editar_archivos_pelicula.click();
                });
        }
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

function exitoMensaje(texto) {
    Swal.fire({
        icon: 'success',
        title: 'Hecho',
        text: texto,
    })
}

function errorMensaje(texto) {
    Swal.fire({
        icon: 'error',
        title: 'Error',
        text: texto,
    })
}