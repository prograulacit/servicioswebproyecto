const url = "https://localhost:44371/api/libro";
const urlCategoria = "https://localhost:44371/api/categorias_libros";
let regexExtensionLibro = new RegExp("(.*?)\.(pdf)$");
let registrosLibros;

function traer_categorias() {
    fetch(urlCategoria)
    .then(function (response) {
        return response.text();
    })
    .then(function (response) {
        let json = JSON.parse(response);
        let html = '<option value="">Ninguno</option>';
        if (json) {

            for (let index = 0; index < json.length; index++) {
                html += `<option value="${json[index].categoria}">${json[index].categoria}</option>`;
            }
        }
        document.getElementById("crearCategoria").innerHTML = html;
        document.getElementById("editarCategoria").innerHTML = html;
    })
    .catch(function (err) {
        console.error(err);
    });
}

function es_archivo_unico(nombre) {
    if (registrosLibros) {
        for (let index = 0; index < registrosLibros.length; index++) {
            if (registrosLibros[index].nombreArchivoDescarga == nombre ||
                registrosLibros[index].nombreArchivoPrevisualizacion == nombre) {
                return false;
            }
        }
    }
    return true
}

function eliminar_elemento(id, nombreArchivoDescarga, nombreArchivoPrevisualizacion) {
    const eliminar_archivo_libro = document.getElementsByClassName("eliminar_archivo_libro")[0];
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
                        document.getElementsByClassName("viejo_nombre_descarga_libro")[0].value = nombreArchivoDescarga;
                        document.getElementsByClassName("viejo_nombre_previsualizacion_libro")[0].value = nombreArchivoPrevisualizacion;
                        eliminar_archivo_libro.click();
                    })
                );
            }
        }
    })
}

function crear_elemento() {
    const descargar_archivo_libro = document.getElementsByClassName("descargar_archivo_libro")[0];
    const crear_nombre = document.getElementsByClassName("crear_nombre")[0].value
    const crear_categoria = document.getElementsByClassName("crear_categoria")[0].value
    const crear_autor = document.getElementsByClassName("crear_autor")[0].value
    const crear_idioma = document.getElementsByClassName("crear_idioma")[0].value
    const crear_editorial = document.getElementsByClassName("crear_editorial")[0].value
    const crear_anioPublicacion = document.getElementsByClassName("crear_anioPublicacion")[0].value
    const nombre_archivo_libro = document.getElementsByClassName("nombre_archivo_libro")[0].value
    const nombre_previsualizacion_libro = document.getElementsByClassName("nombre_previsualizacion_libro")[0].value
    const crear_monto = document.getElementsByClassName("crear_monto")[0].value
    const archivo_libro = document.getElementsByClassName("archivo_libro")[0].files
    const archivo_libro_prev = document.getElementsByClassName("archivo_libro_prev")[0].files

    if (crear_nombre != "" &&
        crear_categoria != "" &&
        crear_autor != "" &&
        crear_idioma != "" &&
        crear_editorial != "" &&
        crear_anioPublicacion != "" &&
        nombre_archivo_libro != "" &&
        nombre_previsualizacion_libro != "" &&
        crear_monto != "" &&
        archivo_libro.length > 0 &&
        archivo_libro_prev.length > 0) {

        var json_request = {
            "nombre": crear_nombre,
            "categoria": crear_categoria,
            "autor": crear_autor,
            "idioma": crear_idioma,
            "editorial": crear_editorial,
            "anioPublicacion": crear_anioPublicacion,
            "nombreArchivoDescarga": nombre_archivo_libro,
            "nombreArchivoPrevisualizacion": nombre_previsualizacion_libro,
            "monto": crear_monto
        };

        if (!es_archivo_unico(nombre_archivo_libro)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'El nombre de archivo de libro ingresado ya existe.',
            })
        } else if (!es_archivo_unico(nombre_previsualizacion_libro)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'El nombre de archivo de previsualizacion ingresado ya existe.',
            })
        } else if (!regexExtensionLibro.test(nombre_archivo_libro) || !regexExtensionLibro.test(nombre_previsualizacion_libro)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de libros y previsualizacion deben tener extension PDF.',
            })
        } else if (nombre_archivo_libro === nombre_previsualizacion_libro) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de libros y previsualizacion no pueden tener el mismo nombre.',
            })
        } else if (archivo_libro[0].size / 1024 / 1024 / 1024 > 1 || archivo_libro_prev[0].size / 1024 / 1024 / 1024 > 1) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'No se permiten archivos mayores a 1GB',
            })
        } else {
            fetch(url, {
                method: 'POST',
                body: JSON.stringify(json_request), // data can be `string` or {object}!
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(res => res.json())
                .catch(error => console.error('Error:', error))
                .then((response) => {
                    descargar_archivo_libro.click();
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
            registrosLibros = json;
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
            `
            <br>
            <div class="subtitulo">
                Total de registros: ${obj.length}
            </div>
                        <table class="table table-striped">
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Nombre</th>
                                <th scope="col">Categoria</th>
                                <th scope="col">Autor</th>
                                <th scope="col">Idioma</th>
                                <th scope="col">Editorial</th>
                                <th scope="col">Año de publicación</th>
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
                                <td>` + obj[index].categoria + `</td>
                                <td>` + obj[index].autor + `</td>
                                <td>` + obj[index].idioma + `</td>
                                <td>` + obj[index].editorial + `</td>
                                <td>` + obj[index].anioPublicacion + `</td>
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
                    document.getElementsByClassName("editar_categoria")[0].value = json[index].categoria;
                    document.getElementsByClassName("editar_autor")[0].value = json[index].autor;
                    document.getElementsByClassName("editar_idioma")[0].value = json[index].idioma;
                    document.getElementsByClassName("editar_editorial")[0].value = json[index].editorial;
                    document.getElementsByClassName("editar_anioPublicacion")[0].value = json[index].anioPublicacion;
                    document.getElementsByClassName("editar_nombre_descarga_libro")[0].value = json[index].nombreArchivoDescarga;
                    document.getElementsByClassName("editar_nombre_previsualizacion_libro")[0].value = json[index].nombreArchivoPrevisualizacion;
                    document.getElementsByClassName("editar_monto")[0].value = json[index].monto;
                    document.getElementsByClassName("viejo_nombre_descarga_libro")[0].value = json[index].nombreArchivoDescarga;
                    document.getElementsByClassName("viejo_nombre_previsualizacion_libro")[0].value = json[index].nombreArchivoPrevisualizacion;
                }
            }

        })
        .catch(function (err) {
            console.error(err);
        });
}

function guardar_cambios() {
    const editar_archivos_libro = document.getElementsByClassName("editar_archivos_libro")[0]
    const editar_id = document.getElementsByClassName("editar_id")[0].value
    const editar_nombre = document.getElementsByClassName("editar_nombre")[0].value
    const editar_categoria = document.getElementsByClassName("editar_categoria")[0].value
    const editar_autor = document.getElementsByClassName("editar_autor")[0].value
    const editar_idioma = document.getElementsByClassName("editar_idioma")[0].value
    const editar_editorial = document.getElementsByClassName("editar_editorial")[0].value
    const editar_anioPublicacion = document.getElementsByClassName("editar_anioPublicacion")[0].value
    const editar_nombre_descarga_libro = document.getElementsByClassName("editar_nombre_descarga_libro")[0].value
    const editar_nombre_previsualizacion_libro = document.getElementsByClassName("editar_nombre_previsualizacion_libro")[0].value
    const editar_monto = document.getElementsByClassName("editar_monto")[0].value
    const editar_archivo_libro = document.getElementsByClassName("editar_archivo_libro")[0].files
    const editar_archivo_libro_prev = document.getElementsByClassName("editar_archivo_libro_prev")[0].files
    const viejo_nombre_descarga_libro = document.getElementsByClassName("viejo_nombre_descarga_libro")[0].value
    const viejo_nombre_previsualizacion_libro = document.getElementsByClassName("viejo_nombre_previsualizacion_libro")[0].value

    if (editar_id != "" &&
        editar_nombre != "" &&
        editar_categoria != "" &&
        editar_autor != "" &&
        editar_idioma != "" &&
        editar_editorial != "" &&
        editar_anioPublicacion != "" &&
        editar_nombre_descarga_libro != "" &&
        editar_nombre_previsualizacion_libro != "" &&
        editar_monto != "") {

        var json_request = {
            "ID": editar_id,
            "nombre": editar_nombre,
            "categoria": editar_categoria,
            "autor": editar_autor,
            "idioma": editar_idioma,
            "editorial": editar_editorial,
            "anioPublicacion": editar_anioPublicacion,
            "nombreArchivoDescarga": editar_nombre_descarga_libro,
            "nombreArchivoPrevisualizacion": editar_nombre_previsualizacion_libro,
            "monto": editar_monto
        };

        if ((editar_nombre_descarga_libro != viejo_nombre_descarga_libro) && !es_archivo_unico(editar_nombre_descarga_libro)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'El nombre de archivo de musica ingresado ya existe.',
            })
        } else if ((editar_nombre_previsualizacion_libro != viejo_nombre_previsualizacion_libro) && !es_archivo_unico(editar_nombre_previsualizacion_libro)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'El nombre de archivo de previsualizacion ingresado ya existe.',
            })
        } else if (!regexExtensionLibro.test(editar_nombre_descarga_libro) || !regexExtensionLibro.test(editar_nombre_previsualizacion_libro)) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de libros y previsualizacion deben tener extension PDF.',
            })
        } else if (editar_nombre_descarga_libro === editar_nombre_previsualizacion_libro) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Los archivos de libros y previsualizacion no pueden tener el mismo nombre.',
            })
        } else if ((editar_archivo_libro.length > 0 && editar_archivo_libro[0].size / 1024 / 1024 / 1024 > 1) ||
            (editar_archivo_libro_prev.length > 0 && editar_archivo_libro_prev[0].size / 1024 / 1024 / 1024 > 1)) {
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
                    editar_archivos_libro.click();
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