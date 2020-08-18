const API_URL = 'https://localhost:44371/api/';
const API_URL_ARTICULOSASOCIADOS = API_URL + 'transaccion?ID=asociada';

const contenido = document.getElementById("contenido");

/////////////////////////////////////////////////////////
/// Funciones de generacion de tablas.
/////////////////////////////////////////////////////////

function generarTabla_Peliculas() {
    fetch(API_URL_ARTICULOSASOCIADOS)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            console.log("Exito en cargar transacciones.");
            // Trae transacciones de la base de datos.
            let transacciones = JSON.parse(response);
            console.log(transacciones);

            if (transacciones != null) {
                fetch(API_URL + "pelicula")
                    .then(function (response) {
                        return response.text();
                    })
                    .then(function (response) {
                        let peliculas = JSON.parse(response);
                        let peliculas_conPropiedadDelUsuario = [];
                        if (peliculas != null) {
                            for (var i = 0; i < transacciones.length; i++) {
                                for (var j = 0; j < peliculas.length; j++) {
                                    if (transacciones[i]
                                        .consecutivoProductoID == peliculas[j].id) {
                                        peliculas_conPropiedadDelUsuario
                                            .push(peliculas[j]);
                                        break;
                                    }
                                }
                            }

                            if (peliculas_conPropiedadDelUsuario.length > 0) {
                                construirTabla_peliculas(peliculas_conPropiedadDelUsuario);
                            } else {
                                let mensaje = "Usted no ha comprado ninguna pélicula.";
                                mensaje_alertaAzul(mensaje);
                            }
                        } else {
                            let mensaje = "Usted no ha comprado ninguna pélicula.";
                            mensaje_alertaAzul(mensaje);
                        }
                    })
                    .catch(function (err) {
                        console.error(err);
                    });
            } else {
                let mensaje = "Usted no ha comprado ninguna pélicula.";
                mensaje_alertaAzul(mensaje);
            }
        })
        .catch(function (err) {
            console.error("Error: " + err);
            document.getElementById("contenido").innerHTML =
                `
                <div class="alert alert-danger" role="alert">
                    Ha ocurrido un error.
                </div>
                `;
        });
}

function generarTabla_Musica() {
    fetch(API_URL_ARTICULOSASOCIADOS)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            console.log("Exito en cargar transacciones.");
            // Trae transacciones de la base de datos.
            let transacciones = JSON.parse(response);
            console.log(transacciones);

            if (transacciones != null) {
                fetch(API_URL + "musica")
                    .then(function (response) {
                        return response.text();
                    })
                    .then(function (response) {
                        let musicas = JSON.parse(response);
                        let musica_conPropiedadDelUsuario = [];

                        if (musicas != null) {
                            for (var i = 0; i < transacciones.length; i++) {
                                for (var j = 0; j < musicas.length; j++) {
                                    if (transacciones[i]
                                        .consecutivoProductoID == musicas[j].id) {
                                        musica_conPropiedadDelUsuario
                                            .push(musicas[j]);
                                        break;
                                    }
                                }
                            }

                            if (musica_conPropiedadDelUsuario.length > 0) {
                                construirTabla_musica(musica_conPropiedadDelUsuario);
                            } else {
                                let mensaje = "Usted no ha comprado ninguna música.";
                                mensaje_alertaAzul(mensaje);
                            }
                        } else {
                            let mensaje = "Usted no ha comprado ninguna música.";
                            mensaje_alertaAzul(mensaje);
                        }
                    }).catch(function (err) {
                        console.error(err);
                    });
            } else {
                let mensaje = "Usted no ha comprado ninguna música.";
                mensaje_alertaAzul(mensaje);
            }
        })
        .catch(function (err) {
            console.error("Error: " + err);
            document.getElementById("contenido").innerHTML =
                `
                <div class="alert alert-danger" role="alert">
                    Ha ocurrido un error.
                </div>
                `;
        });
}

function generarTabla_Libro() {
    fetch(API_URL_ARTICULOSASOCIADOS)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            console.log("Exito en cargar transacciones.");
            // Trae transacciones de la base de datos.
            let transacciones = JSON.parse(response);
            console.log(transacciones);

            if (transacciones != null) {
                fetch(API_URL + "libro")
                    .then(function (response) {
                        return response.text();
                    })
                    .then(function (response) {
                        let libros = JSON.parse(response);
                        let libros_conPropiedadDelUsuario = [];

                        for (var i = 0; i < transacciones.length; i++) {
                            for (var j = 0; j < libros.length; j++) {
                                if (transacciones[i]
                                    .consecutivoProductoID == libros[j].id) {
                                    libros_conPropiedadDelUsuario
                                        .push(libros[j]);
                                    break;
                                }
                            }
                        }

                        if (libros_conPropiedadDelUsuario.length > 0) {
                            construirTabla_libro(libros_conPropiedadDelUsuario);
                        } else {
                            let mensaje = "Usted no ha comprado ningun libro.";
                            mensaje_alertaAzul(mensaje);
                        }
                    })
                    .catch(function (err) {
                        console.error(err);
                    });
            } else {
                let mensaje = "Usted no ha comprado ningun libro.";
                mensaje_alertaAzul(mensaje);
            }
        })
        .catch(function (err) {
            console.error("Error: " + err);
            document.getElementById("contenido").innerHTML =
                `
                <div class="alert alert-danger" role="alert">
                    Ha ocurrido un error.
                </div>
                `;
        });
}

/////////////////////////////////////////////////////////
/// Funciones de creación de tablas.
/////////////////////////////////////////////////////////

function construirTabla_peliculas(peliculas) {
    let html = "";

    html +=
        `
        <br>
        <div>
            Total de péliculas compradas: ${peliculas.length}
        </div>
        <br>
        <table class="table table-bordered">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Género</th>
                <th scope="col">Año</th>
                <th scope="col">Idioma</th>
                <th scope="col">Actores</th>
                <th scope="col">Acciones</th>
            </tr>
        `;
    for (let i = 0; i < peliculas.length; i++) {
        html +=
            `<tr>
                <td>${peliculas[i].id}</td>
                <td>${peliculas[i].nombre}</td>
                <td>${peliculas[i].genero}</td>
                <td>${peliculas[i].anio}</td>
                <td>${peliculas[i].idioma}</td>
                <td>${peliculas[i].actores}</td>
                <td><a href="#"
                    onclick="descargarPelicula('${peliculas[i].nombre}', '${peliculas[i].id}', '${peliculas[i].nombreArchivoDescarga}',)">
                    Descargar</a>
                </td>
            </tr>
            `;
    }

    html += "</table>";
    document.getElementById("contenido").innerHTML = html;
}

function construirTabla_musica(musicas) {
    let html = "";

    html +=
        `
        <br>
        <div>
            Total de músicas compradas: ${musicas.length}
        </div>
        <br>
        <table class="table table-bordered">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Género</th>
                <th scope="col">Tipo interpretación</th>
                <th scope="col">Idioma</th>
                <th scope="col">País</th>
                <th scope="col">Disquera</th>
                <th scope="col">Nombre disco</th>
                <th scope="col">Año</th>
                <th scope="col">Acciones</th>
            </tr>
        `;
    for (let i = 0; i < musicas.length; i++) {
        html +=
            `<tr>
                <td>${musicas[i].id}</td>
                <td>${musicas[i].nombre}</td>
                <td>${musicas[i].genero}</td>
                <td>${musicas[i].tipoInterpretacion}</td>
                <td>${musicas[i].idioma}</td>
                <td>${musicas[i].pais}</td>
                <td>${musicas[i].disquera}</td>
                <td>${musicas[i].nombreDisco}</td>
                <td>${musicas[i].anio}</td>
                <td><a href="#"
                    onclick="descargarMusica('${musicas[i].nombre}', '${musicas[i].id}', '${musicas[i].nombreArchivoDescarga}',)">
                    Descargar</a>
                </td>
            </tr>
            `;
    }

    html += "</table>";
    document.getElementById("contenido").innerHTML = html;
}

function construirTabla_libro(libros) {
    let html = "";

    html +=
        `
        <br>
        <div>
            Total de músicas compradas: ${libros.length}
        </div>
        <br>
        <table class="table table-bordered">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Categoría</th>
                <th scope="col">Autor</th>
                <th scope="col">Idioma</th>
                <th scope="col">Editorial</th>
                <th scope="col">Año publicación</th>
                <th scope="col">Acciones</th>
            </tr>
        `;
    for (let i = 0; i < libros.length; i++) {
        html +=
            `<tr>
                <td>${libros[i].id}</td>
                <td>${libros[i].nombre}</td>
                <td>${libros[i].categoria}</td>
                <td>${libros[i].autor}</td>
                <td>${libros[i].idioma}</td>
                <td>${libros[i].editorial}</td>
                <td>${libros[i].anioPublicacion}</td>
                <td><a href="#"
                    onclick="descargarLibro('${libros[i].nombre}', '${libros[i].id}', '${libros[i].nombreArchivoDescarga}',)">
                    Descargar</a>
                </td>
            </tr>
            `;
    }

    html += "</table>";
    document.getElementById("contenido").innerHTML = html;
}

/////////////////////////////////////////////////////////
/// Funciones de descarga.
/////////////////////////////////////////////////////////

function descargarPelicula(nombre, id, nombreArchivoDescarga) {
    fetch(`${API_URL}Descargas/?archivoDescarga=${nombreArchivoDescarga}&nombreDescarga=${nombre}&idConsecutivo=${id}&tipoArchivo=pelicula`, {
        responseType: "arraybuffer"
    })
        .then(function (response) {
            return response.blob();
        })
        .then(function (response) {
            const url = window.URL.createObjectURL(response);
            const a = document.createElement('a');
            a.style.display = 'none';
            a.href = url;
            a.download = nombreArchivoDescarga;
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
        })
        .catch(function (err) {
            console.error(err);
        });
}

function descargarMusica(nombre, id, nombreArchivoDescarga) {
    fetch(`${API_URL}Descargas/?archivoDescarga=${nombreArchivoDescarga}&nombreDescarga=${nombre}&idConsecutivo=${id}&tipoArchivo=musica`, {
        responseType: "arraybuffer"
    })
        .then(function (response) {
            return response.blob();
        })
        .then(function (response) {
            const url = window.URL.createObjectURL(response);
            const a = document.createElement('a');
            a.style.display = 'none';
            a.href = url;
            a.download = nombreArchivoDescarga;
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
        })
        .catch(function (err) {
            console.error(err);
        });
}

function descargarLibro(nombre, id, nombreArchivoDescarga) {
    fetch(`${API_URL}Descargas/?archivoDescarga=${nombreArchivoDescarga}&nombreDescarga=${nombre}&idConsecutivo=${id}&tipoArchivo=libro`, {
        responseType: "arraybuffer"
    })
        .then(function (response) {
            return response.blob();
        })
        .then(function (response) {
            const url = window.URL.createObjectURL(response);
            const a = document.createElement('a');
            a.style.display = 'none';
            a.href = url;
            a.download = nombreArchivoDescarga;
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
        })
        .catch(function (err) {
            console.error(err);
        });
}

/////////////////////////////////////////////////////////
/// Botones de navegación
/////////////////////////////////////////////////////////

const boton_peliculas = document.getElementById("boton_peliculas");
const boton_musica = document.getElementById("boton_musica");
const boton_libros = document.getElementById("boton_libros");

boton_peliculas.addEventListener("click", () => {
    // Añade o quita el Bootstrap active (color azul de selección).
    boton_peliculas.classList.add("active");
    boton_musica.classList.remove("active");
    boton_libros.classList.remove("active");
    generarTabla_Peliculas();
});

boton_musica.addEventListener("click", () => {
    // Añade o quita el Bootstrap active (color azul de selección).
    boton_peliculas.classList.remove("active");
    boton_musica.classList.add("active");
    boton_libros.classList.remove("active");
    generarTabla_Musica();
});

boton_libros.addEventListener("click", () => {
    // Añade o quita el Bootstrap active (color azul de selección).
    boton_peliculas.classList.remove("active");
    boton_musica.classList.remove("active");
    boton_libros.classList.add("active");
    generarTabla_Libro();
});


////////////////////////////////////////////////////////
/// Mensajes de estado.
////////////////////////////////////////////////////////
function mensaje_alertaAzul(description) {
    document.getElementById("contenido").innerHTML =
        `
        <br>
        <div class="alert alert-primary" role="alert">
            ${description}
        </div>
        `;
}

function mensaje_alertaRojo(description) {
    document.getElementById("contenido").innerHTML =
        `
        <br>
        <div class="alert alert-danger" role="alert">
            ${description}
        </div>
        `;
}
