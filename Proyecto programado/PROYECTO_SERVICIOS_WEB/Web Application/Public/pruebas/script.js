// URL de la API.
const url = "https://localhost:44371/api/categorias_libros";

// GET
function obtener_categoriasLibros() {

    const contenedor_id = "http_response_contenido";

    fetch(url)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let json = JSON.parse(response);
            renderizar_categorias_libros(json, contenedor_id);
        })
        .catch(function (err) {
            console.error(err);
            document.getElementById(contenedor_id).innerHTML = "*** Ha ocurrido un error";
        });
}

// POST
function ingresar_datos() {
    const input_id = "ingresar_categoria_contenido";
    const categoria = document.getElementById(input_id).value;

    if (categoria != "") {

        var json_request = {
            categoria: categoria
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
                document.getElementById(input_id).value = "";
                console.log('Success:', response)
                obtener_categoriasLibros();
            });
    } else {
        console.log('Espacios vacios.');
    }
}

// UPDATE
function actualizar_datos() {
    const input_id = "actualizar_categoria_id";
    const categoria_id = "actualizar_categoria_contenido";

    const id = document.getElementById(input_id).value;
    const categoria = document.getElementById(categoria_id).value;

    if (id != "" && categoria != "") {
        var json_request = {
            ID: id,
            categoria: categoria
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
                document.getElementById(input_id).value = "";
                document.getElementById(categoria_id).value = "";
                obtener_categoriasLibros();
            });
    } else {
        console.log("Datos vacios.");
    }
}

// DELETE
function eliminar_datos() {
    const id_id = 'id_eliminar';
    const id = document.getElementById(id_id).value;

    if (id != "") {
        var json_request = {
            ID: id
        };

        fetch(url + '/?ID=' + id, {
            method: 'delete'
        }).then(response =>
            response.json().then((json) => {
                console.log(json);
                document.getElementById(id_id).value = "";
                obtener_categoriasLibros();
            })
        );
    } else {
        console.log("Datos vacios");
    }
}

// TAREAS

// Metodo personalizado para renderizar los datos en el HTML
function renderizar_categorias_libros(json, contenedor_id) {
    if (json != null) {

        let html = "";

        html +=
            `<p>Total de datos: ${json.length}</p>
            <p>Registros: <br>
            `;
        for (let index = 0; index < json.length; index++) {
            html += "ID: " + json[index].id + "<br>" + json[index].categoria + "<br><br>";
        }
        html += "</p>";

        document.getElementById(contenedor_id).innerHTML = "** Cargando datos...";
        document.getElementById(contenedor_id).innerHTML = html;
    } else {
        document.getElementById(contenedor_id).innerHTML = "No hay categorias registradas.";
    }
}