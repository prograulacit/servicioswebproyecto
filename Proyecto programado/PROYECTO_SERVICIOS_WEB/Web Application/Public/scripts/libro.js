﻿const apiURL = "https://localhost:44371";
const urlCategoria = "https://localhost:44371/api/categorias_libros";

function get_data_filtrada(array, llave, data_filtro) {
    let filtrado = array.filter((item) => {
        return Object.keys(item).some((key) => item[llave].includes(data_filtro));
    });
    return filtrado;
}

function traer_previsualizacion(nombreArchivo) {
    fetch(`${apiURL}/api/libro/?archivoPrevisualizacion=${nombreArchivo}`, {
        responseType: "arraybuffer"
    })
        .then(function (response) {
            return response.blob();
        })
        .then(function (response) {
            var objectURL = URL.createObjectURL(response);
            html = `<embed src="${objectURL}" width="800px" height="2100"/>`;
            document.getElementById("embed_file").innerHTML = html;
            document.getElementById("main_container").style.display = "none";
            document.getElementById("libro_container").style.display = "block";
        })
        .catch(function (err) {
            console.error(err);
        });
}

function ir_a_tabla() {
    document.getElementById("main_container").style.display = "block";
    document.getElementById("libro_container").style.display = "none";
}

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
            document.getElementsByClassName("input_libros_Categorias_spinner")[0].style.display = "none";
            document.getElementById("input_libros_Categorias").innerHTML = html;
        })
        .catch(function (err) {
            console.error(err);
        });
}

function cargar_libros(categoria, nombre, autor, idioma, editorial, anioPublicacion) {
    let tablaLibros = document.getElementById("tabla_Libros");
    tablaLibros.innerHTML = "** Cargando datos..."
    fetch(`${apiURL}/api/libro`)
        .then(function (response) { return response.text(); })
        .then(function (response) {
            let json = JSON.parse(response);
            if (json != null) {
                // Aplica filtros
                if (categoria) {
                    json = get_data_filtrada(json, 'categoria', categoria);
                }
                if (nombre) {
                    json = get_data_filtrada(json, 'nombre', nombre);
                }
                if (autor) {
                    json = get_data_filtrada(json, 'autor', autor);
                }
                if (idioma) {
                    json = get_data_filtrada(json, 'idioma', idioma);
                }
                if (editorial) {
                    json = get_data_filtrada(json, 'editorial', editorial);
                }
                if (anioPublicacion) {
                    json = get_data_filtrada(json, 'anioPublicacion', anioPublicacion);
                }

                // Genera tabla
                let html = "";
                html += `<table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Codigo</th>
                                <th>Nombre</th>
                                <th>Categoria</th>
                                <th>Pre visualizar</th>
                                <th>Accion</th>
                            </tr>
                        </thead>
                        <tbody>`;
                for (let index = 0; index < json.length; index++) {
                    html += `<tr>
                            <td>${json[index].id}</td>
                            <td>${json[index].nombre}</td>
                            <td>${json[index].categoria}</td>
                            <td><a href="#" onclick="traer_previsualizacion('${json[index].nombreArchivoPrevisualizacion}')">Ver</a></td>
                            <td><a onclick="establecerProductoAComprar('${json[index].id}')" href="#">Comprar</a></td>
                        </tr>`;
                }
                html += "</tbody></table>";
                tablaLibros.innerHTML = html;
            } else {
                tablaLibros.innerHTML = "No hay registros de libros.";
            }
        })
        .catch(function (err) {
            console.error(err);
            tablaLibros.innerHTML = "*** Ha ocurrido un error";
        });
}

function button_submit_libro_buscar() {
    let inputLibrosCategorias = document.getElementById("input_libros_Categorias");
    let inputLibrosNombre = document.getElementById("input_libros_Nombre");
    let inputLibrosAutor = document.getElementById("input_libros_Autor");
    let inputLibrosIdioma = document.getElementById("input_libros_Idioma");
    let inputLibrosEditorial = document.getElementById("input_libros_Editorial");
    let inputLibrosAnio = document.getElementById("input_libros_Anio");
    cargar_libros(inputLibrosCategorias.value, inputLibrosNombre.value, inputLibrosAutor.value, inputLibrosIdioma.value, inputLibrosEditorial.value, inputLibrosAnio.value)
}