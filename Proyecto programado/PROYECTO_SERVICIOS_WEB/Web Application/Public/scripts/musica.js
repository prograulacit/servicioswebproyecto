const apiURL = "https://localhost:44371";
const urlGenero = "https://localhost:44371/api/generos_musica";

function get_data_filtrada(array, llave, data_filtro) {
    let filtrado = array.filter((item) => {
        return Object.keys(item).some((key) => item[llave].includes(data_filtro));
    });
    return filtrado;
}

function traer_previsualizacion(nombreArchivo) {
    fetch(`${apiURL}/api/musica/?archivoPrevisualizacion=${nombreArchivo}`, {
        responseType: "arraybuffer"
    })
        .then(function (response) {
            return response.blob();
        })
        .then(function (response) {
            var objectURL = URL.createObjectURL(response);
            html = `<source src="${objectURL}" type="audio/mp3">`;
            document.getElementById("musica_player").innerHTML = html;
            document.getElementById("main_container").style.display = "none";
            document.getElementById("audio_container").style.display = "block";
        })
        .catch(function (err) {
            console.error(err);
        });
}

function ir_a_tabla() {
    document.getElementById("main_container").style.display = "block";
    document.getElementById("audio_container").style.display = "none";
}

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
            document.getElementsByClassName("input_musica_Genero_spinner")[0].style.display = "none";
            document.getElementById("input_musica_Genero").innerHTML = html;
        })
        .catch(function (err) {
            console.error(err);
        });
}

function cargar_musica(genero, nombre, tipoInterpretacion, idioma, pais, disquera, nombreDisco, anio) {
    let tablaMusica = document.getElementById("tabla_Musica");
    tablaMusica.innerHTML = "** Cargando datos..."
    fetch(`${apiURL}/api/musica`)
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
                if (tipoInterpretacion) {
                    json = get_data_filtrada(json, 'tipoInterpretacion', tipoInterpretacion);
                }
                if (idioma) {
                    json = get_data_filtrada(json, 'idioma', idioma);
                }
                if (pais) {
                    json = get_data_filtrada(json, 'pais', pais);
                }
                if (disquera) {
                    json = get_data_filtrada(json, 'disquera', disquera);
                }
                if (nombreDisco) {
                    json = get_data_filtrada(json, 'nombreDisco', nombreDisco);
                }
                if (anio) {
                    json = get_data_filtrada(json, 'anio', anio);
                }

                // Genera tabla
                let html = "";
                html += `<table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Codigo</th>
                                <th>Nombre</th>
                                <th>Disco</th>
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
                            <td>${json[index].nombreDisco}</td>
                            <td>${json[index].genero}</td>
                            <td><a href="#" onclick="traer_previsualizacion('${json[index].nombreArchivoPrevisualizacion}')">Ver</a></td>
                            <td>comprar</td>
                        </tr>`;
                }
                html += "</tbody></table>";
                tablaMusica.innerHTML = html;
            } else {
                tablaMusica.innerHTML = "No hay registros de Musica.";
            }
        })
        .catch(function (err) {
            console.error(err);
            tablaMusica.innerHTML = "*** Ha ocurrido un error";
        });
}

function button_submit_musica_buscar() {
    let inputMusicaGenero = document.getElementById("input_musica_Genero");
    let inputMusicaNombre = document.getElementById("input_musica_Nombre");
    let inputMusicaTipo = document.getElementById("input_musica_Tipo");
    let inputMusicaIdioma = document.getElementById("input_musica_Idioma");
    let inputMusicaPais = document.getElementById("input_musica_Pais");
    let inputMusicaDisquera = document.getElementById("input_musica_Disquera");
    let inputMusicaDisco = document.getElementById("input_musica_Disco");
    let inputMusicaAnio = document.getElementById("input_musica_Anio");
    cargar_musica(inputMusicaGenero.value, inputMusicaNombre.value, inputMusicaTipo.value, inputMusicaIdioma.value,
                  inputMusicaPais.value, inputMusicaDisquera.value, inputMusicaDisco.value, inputMusicaAnio.value)
}