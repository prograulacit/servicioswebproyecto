const url = "https://localhost:44371/api/parametros";

function traer_datos() {
    fetch(url)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let json = JSON.parse(response);
            document.getElementById("pre_libros").value = json[0].rutaAlmacenamientoPrevisualizacionLibros;
            document.getElementById("alm_libros").value = json[0].rutaAlmacenamientoLibros;

            document.getElementById("pre_peliculas").value = json[0].rutaAlmacenamientoPrevisualizacionPeliculas;
            document.getElementById("alm_peliculas").value = json[0].rutaAlmacenamientoPeliculas;

            document.getElementById("pre_musica").value = json[0].rutaAlmacenamientoPrevisualizacionMusica;
            document.getElementById("alm_musica").value = json[0].rutaAlmacenamientoMusica;

        })
        .catch(function (err) {
            console.error(err);
            document.getElementById(contenedor_id).innerHTML = "*** Ha ocurrido un error";
        });
}

function actualizar_parametros() {

    const pre_libros = document.getElementById("pre_libros").value;
    const alm_libros = document.getElementById("alm_libros").value;

    const pre_peliculas = document.getElementById("pre_peliculas").value
    const alm_peliculas = document.getElementById("alm_peliculas").value

    const pre_musica = document.getElementById("pre_musica").value
    const alm_musica = document.getElementById("alm_musica").value

    if (pre_libros != "" &&
        alm_libros != "" &&
        pre_peliculas != "" &&
        alm_peliculas != "" &&
        pre_musica != "" &&
        alm_musica != "") {

        var json_request = {
            "ID": "par",
            "rutaAlmacenamientoPrevisualizacionLibros": pre_libros,
            "rutaAlmacenamientoLibros": alm_libros,
            "rutaAlmacenamientoPrevisualizacionPeliculas": pre_peliculas,
            "rutaAlmacenamientoPeliculas": alm_peliculas,
            "rutaAlmacenamientoPrevisualizacionMusica": pre_musica,
            "rutaAlmacenamientoMusica": alm_musica
        };
        fetch(url, {
            method: 'PUT',
            body: JSON.stringify(json_request),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .catch(error => console.error('Error:', error))
            .then((response) => {
                console.log(response);
                traer_datos();
            });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Por favor, no deje ningun parametro vacio.',
        })
    }
}
