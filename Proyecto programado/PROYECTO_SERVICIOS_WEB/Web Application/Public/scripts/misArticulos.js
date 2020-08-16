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

/////////////////////////////////////////////////////////
/// Funciones de descarga.
/////////////////////////////////////////////////////////

function descargarPelicula(nombre, id, nombreArchivoDescarga) {
    alert("Nombre de la pélicula: " + nombre + "\n ID: " + id + "\nNombre archivo descarga: " + nombreArchivoDescarga);

    // Aquí va el código de descarga...
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
