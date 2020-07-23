﻿const apiURL = "https://localhost:44371";

function get_data_filtrada(array, llave, data_filtro) {
    let filtrado = array.filter((item) => {
        return Object.keys(item).some((key) => item[llave].includes(data_filtro));
    });
    return filtrado;
}

function cargar_peliculas(genero, nombre, anio, idioma, actores) {
    let tablaPeliculas = document.getElementById("tabla_Peliculas");
    tablaPeliculas.innerHTML = "** Cargando datos..."
    fetch(`${apiURL}/api/pelicula`)
    .then(function (response) { return response.text(); })
    .then(function (response) {
        let json = JSON.parse(response);
        if (json != null) {
            // Aplica filtros
            if (genero) {
                json = get_data_filtrada(json, 'genero', genero);
            }
            if (nombre) {   
                json = get_data_filtrada(json, 'nombre', nombre);
            }
            if (anio) {
                json = get_data_filtrada(json, 'anio', anio);
            }
            if (idioma) {
                json = get_data_filtrada(json, 'idioma', idioma);
            }
            if (actores) {
                json = get_data_filtrada(json, 'actores', actores);
            }

            // Genera tabla
            let html = "";
            html += `<table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Codigo</th>
                                <th>Nombre</th>
                                <th>Genero</th>
                                <th>Pre visualizar</th>
                                <th>Comprar</th>
                            </tr>
                        </thead>
                        <tbody>`;
            for (let index = 0; index < json.length; index++) {
                html += `<tr>
                            <td>${json[index].id}</td>
                            <td>${json[index].nombre}</td>
                            <td>${json[index].genero}</td>
                            <td><a href="/${json[index].nombreArchivoPrevisualizacion}">Ver</a></td>
                            <td>comprar</td>
                        </tr>`;
            }
            html += "</tbody></table>";
            tablaPeliculas.innerHTML = html;
        } else {
            tablaPeliculas.innerHTML = "No hay registros de peliculas.";
        }
    })
    .catch(function (err) {
        console.error(err);
        tablaPeliculas.innerHTML = "*** Ha ocurrido un error";
    });
}

function button_submit_pelicula_buscar() {
    let inputPeliGenero = document.getElementById("input_peli_genero");
    let inputPeliNombre = document.getElementById("input_peli_nombre");
    let inputPeliAnio = document.getElementById("input_peli_anio");
    let inputPeliIdioma = document.getElementById("input_peli_idioma");
    let inputPeliActores = document.getElementById("input_peli_actores");
    cargar_peliculas(inputPeliGenero.value, inputPeliNombre.value, inputPeliAnio.value, inputPeliIdioma.value, inputPeliActores.value)
}