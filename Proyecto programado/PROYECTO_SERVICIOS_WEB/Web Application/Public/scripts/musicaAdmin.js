const url = "https://localhost:44371/api/musica";
const urlGenero = "https://localhost:44371/api/generos_musica";
let regexExtensionMusica = new RegExp("(.*?)\.(mp3|m4a|flac|mp4|wav|wma|aac)$"); 
let registrosMusica;

function traer_generos() {
    fetch(urlGenero)
    .then(function (response) {
        return response.text();
    })
    .then(function (response) {
        let json = JSON.parse(response);
        let html = '<option value="">Ninguno</option>';
        if (json) {

            for (let index = 0; index < json.length; index++) {
                html += `<option value="${json[index].genero}">${json[index].genero}</option>`;
            }
        }
        document.getElementById("crearGenero").innerHTML = html;
        document.getElementById("editarGenero").innerHTML = html;
    })
    .catch(function (err) {
        console.error(err);
    });
}

function es_archivo_unico(nombre) {
    if (registrosMusica) {
        for (let index = 0; index < registrosMusica.length; index++) {
            if (registrosMusica[index].nombreArchivoDescarga == nombre ||
                registrosMusica[index].nombreArchivoPrevisualizacion == nombre) {
                return false;
            }
        }
    }
    return true
}

function eliminar_elemento(id, nombreArchivoDescarga, nombreArchivoPrevisualizacion) {
    const eliminar_archivo_musica = document.getElementsByClassName("eliminar_archivo_musica")[0];
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
                        document.getElementsByClassName("viejo_nombre_descarga_musica")[0].value = nombreArchivoDescarga;
                        document.getElementsByClassName("viejo_nombre_previsualizacion_musica")[0].value = nombreArchivoPrevisualizacion;
                        eliminar_archivo_musica.click();
                    })
                );
            }
        }
    })
}

function crear_elemento() {
    const descargar_archivo_musica = document.getElementsByClassName("descargar_archivo_musica")[0];
    const crear_nombre = document.getElementsByClassName("crear_nombre_musica")[0].value;
    const crear_genero = document.getElementsByClassName("crear_genero_musica")[0].value;
    const crear_tipoInterpretacion = document.getElementsByClassName("crear_tipoInterpretacion_musica")[0].value;
    const crear_idioma = document.getElementsByClassName("crear_idioma_musica")[0].value;
    const crear_pais = document.getElementsByClassName("crear_pais_musica")[0].value;
    const crear_disquera = document.getElementsByClassName("crear_disquera_musica")[0].value;
    const crear_nombreDisco = document.getElementsByClassName("crear_nombreDisco_musica")[0].value;
    const crear_anio = document.getElementsByClassName("crear_anio_musica")[0].value;
    const nombre_archivo_musica = document.getElementsByClassName("nombre_archivo_musica")[0].value;
    const nombre_previsualizacion_musica = document.getElementsByClassName("nombre_previsualizacion_musica")[0].value;
    const crear_monto = document.getElementsByClassName("crear_monto_musica")[0].value;
    const archivo_musica = document.getElementsByClassName("archivo_musica")[0].files;
    const archivo_musica_prev = document.getElementsByClassName("archivo_musica_prev")[0].files;

    if (crear_nombre != "" &&
        crear_genero != "" &&
        crear_tipoInterpretacion != "" &&
        crear_idioma != "" &&
        crear_pais != "" &&
        crear_disquera != "" &&
        crear_nombreDisco != "" &&
        crear_anio != "" &&
        nombre_archivo_musica != "" &&
        nombre_previsualizacion_musica != "" &&
        crear_monto != "" &&
        archivo_musica.length > 0 &&
        archivo_musica_prev.length > 0) {

        if (!es_archivo_unico(nombre_archivo_musica)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'El nombre de archivo de musica ingresado ya existe.',
            })
        } else if (!es_archivo_unico(nombre_previsualizacion_musica)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'El nombre de archivo de previsualizacion ingresado ya existe.',
            })
        } else if (!regexExtensionMusica.test(nombre_archivo_musica) || !regexExtensionMusica.test(nombre_previsualizacion_musica)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de musica y previsualizacion deben tener extension MP3, MP4, WAV, M4A, FLAC, WMA o AAC',
            })
        } else if (nombre_archivo_musica === nombre_previsualizacion_musica) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de musica y previsualizacion no pueden tener el mismo nombre.',
            })
        } else if (archivo_musica[0].size / 1024 / 1024 / 1024 > 1 || archivo_musica_prev[0].size / 1024 / 1024 / 1024 > 1) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'No se permiten archivos mayores a 1GB',
            })
        } else {
            var json_request = {
                "nombre": crear_nombre,
                "genero": crear_genero,
                "tipoInterpretacion": crear_tipoInterpretacion,
                "idioma": crear_idioma,
                "pais": crear_pais,
                "disquera": crear_disquera,
                "nombreDisco": crear_nombreDisco,
                "anio": crear_anio,
                "nombreArchivoDescarga": nombre_archivo_musica,
                "nombreArchivoPrevisualizacion": nombre_previsualizacion_musica,
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
                    descargar_archivo_musica.click();
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
            registrosMusica = json;
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
                                <th scope="col">Tipo de interpretacion</th>
                                <th scope="col">Idioma</th>
                                <th scope="col">Pais</th>
                                <th scope="col">Disquera</th>
                                <th scope="col">Nombre del disco</th>
                                <th scope="col">Año</th>
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
                                <td>` + obj[index].tipoInterpretacion + `</td>
                                <td>` + obj[index].idioma + `</td>
                                <td>` + obj[index].pais + `</td>
                                <td>` + obj[index].disquera + `</td>
                                <td>` + obj[index].nombreDisco + `</td>
                                <td>` + obj[index].anio + `</td>
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
                    document.getElementsByClassName("editar_id_musica")[0].value = json[index].id;
                    document.getElementsByClassName("editar_nombre_musica")[0].value = json[index].nombre;
                    document.getElementsByClassName("editar_genero_musica")[0].value = json[index].genero;
                    document.getElementsByClassName("editar_tipoInterpretacion_musica")[0].value = json[index].tipoInterpretacion;
                    document.getElementsByClassName("editar_idioma_musica")[0].value = json[index].idioma;
                    document.getElementsByClassName("editar_pais_musica")[0].value = json[index].pais;
                    document.getElementsByClassName("editar_disquera_musica")[0].value = json[index].disquera;
                    document.getElementsByClassName("editar_nombreDisco_musica")[0].value = json[index].nombreDisco;
                    document.getElementsByClassName("editar_anio_musica")[0].value = json[index].anio;
                    document.getElementsByClassName("editar_nombre_descarga_musica")[0].value = json[index].nombreArchivoDescarga;
                    document.getElementsByClassName("editar_nombre_previsualizacion_musica")[0].value = json[index].nombreArchivoPrevisualizacion;
                    document.getElementsByClassName("viejo_nombre_descarga_musica")[0].value = json[index].nombreArchivoDescarga;
                    document.getElementsByClassName("viejo_nombre_previsualizacion_musica")[0].value = json[index].nombreArchivoPrevisualizacion;
                    document.getElementsByClassName("editar_monto_musica")[0].value = json[index].monto;
                }
            }

        })
        .catch(function (err) {
            console.error(err);
        });
}

function guardar_cambios() {
    const editar_archivos_musica = document.getElementsByClassName("editar_archivos_musica")[0]
    const editar_id = document.getElementsByClassName("editar_id_musica")[0].value
    const editar_nombre = document.getElementsByClassName("editar_nombre_musica")[0].value
    const editar_genero = document.getElementsByClassName("editar_genero_musica")[0].value
    const editar_tipoInterpretacion = document.getElementsByClassName("editar_tipoInterpretacion_musica")[0].value
    const editar_idioma = document.getElementsByClassName("editar_idioma_musica")[0].value
    const editar_pais = document.getElementsByClassName("editar_pais_musica")[0].value
    const editar_disquera = document.getElementsByClassName("editar_disquera_musica")[0].value
    const editar_nombreDisco = document.getElementsByClassName("editar_nombreDisco_musica")[0].value
    const editar_anio = document.getElementsByClassName("editar_anio_musica")[0].value
    const editar_descarga = document.getElementsByClassName("editar_nombre_descarga_musica")[0].value
    const editar_previsualizacion = document.getElementsByClassName("editar_nombre_previsualizacion_musica")[0].value
    const editar_monto = document.getElementsByClassName("editar_monto_musica")[0].value
    const editar_archivo_musica = document.getElementsByClassName("editar_archivo_musica")[0].files
    const editar_archivo_musica_prev = document.getElementsByClassName("editar_archivo_musica_prev")[0].files
    const viejo_nombre_descarga_musica = document.getElementsByClassName("viejo_nombre_descarga_musica")[0].value
    const viejo_nombre_previsualizacion_musica = document.getElementsByClassName("viejo_nombre_previsualizacion_musica")[0].value

    if (editar_id != "" &&
        editar_nombre != "" &&
        editar_genero != "" &&
        editar_tipoInterpretacion != "" &&
        editar_idioma != "" &&
        editar_pais != "" &&
        editar_disquera != "" &&
        editar_nombreDisco != "" &&
        editar_anio != "" &&
        editar_descarga != "" &&
        editar_previsualizacion != "" &&
        editar_monto != "") {

        var json_request = {
            "ID": editar_id,
            "nombre": editar_nombre,
            "genero": editar_genero,
            "tipoInterpretacion": editar_tipoInterpretacion,
            "idioma": editar_idioma,
            "pais": editar_pais,
            "disquera": editar_disquera,
            "nombreDisco": editar_nombreDisco,
            "anio": editar_anio,
            "nombreArchivoDescarga": editar_descarga,
            "nombreArchivoPrevisualizacion": editar_previsualizacion,
            "monto": editar_monto
        };

        if ((editar_descarga != viejo_nombre_descarga_musica) && !es_archivo_unico(editar_descarga)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'El nombre de archivo de musica ingresado ya existe.',
            })
        } else if ((editar_previsualizacion != viejo_nombre_previsualizacion_musica) && !es_archivo_unico(editar_previsualizacion)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'El nombre de archivo de previsualizacion ingresado ya existe.',
            })
        } else if (!regexExtensionMusica.test(editar_descarga) || !regexExtensionMusica.test(editar_previsualizacion)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de musica y previsualizacion deben tener extension MP3, MP4, WAV, M4A, FLAC, WMA o AAC',
            })
        } else if (editar_descarga === editar_previsualizacion) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de musica y previsualizacion no pueden tener el mismo nombre.',
            })
        } else if ((editar_archivo_musica.length > 0 && editar_archivo_musica[0].size / 1024 / 1024 / 1024 > 1) ||
            (editar_archivo_musica_prev.length > 0 && editar_archivo_musica_prev[0].size / 1024 / 1024 / 1024 > 1)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'No se permiten archivos mayores a 1GB',
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
                    editar_archivos_musica.click();
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