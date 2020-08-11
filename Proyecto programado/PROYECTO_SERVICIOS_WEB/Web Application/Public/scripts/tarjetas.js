const elemento_tarjetasRegistradas = document.getElementById("tarjetas_registradas");
const API_URI = "https://localhost:44371/api/tarjeta?user_id=asociada";
const API_URI_ELIMINAR = "https://localhost:44371/api/tarjeta";

const API_COMPRAMETODODEPAGO = "https://localhost:44371/api/CompraMetodoDePago";

function cargar_tarjetas() {
    fetch(API_URI)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let obj_tarjetas = JSON.parse(response);
            crearTablaDeTarjetas(obj_tarjetas);
        })
        .catch(function (err) {
            console.error(err);
            document.getElementById("tarjetas_registradas").innerHTML =
                `<div class="alert alert-danger" role="alert">
                Ha ocurrido un error al intentar cargar las tarjetas.
            </div>`;
        });
}

function crearTablaDeTarjetas(obj_tarjetas) {
    if (obj_tarjetas != null && obj_tarjetas.length > 0) {

        let html = "";

        html +=
            `
            <div class="subtitulo">
                Tarjetas registradas
            </div>
            <div>
                Total de tarjetas: ${obj_tarjetas.length}
            </div>
            <br>
            <table class="table table-bordered">
                <tr>
                    <th scope="col">Número</th>
                    <th scope="col">Tipo</th>
                    <th scope="col">Saldo</th>
                    <th scope="col">Accion</th>
                </tr>
            `;
        for (let index = 0; index < obj_tarjetas.length; index++) {

            // Se extrae el numero de tarjeta.
            let numeroTarjeta = "xxxx" +
                obj_tarjetas[index].numeroTarjeta.charAt(12) +
                obj_tarjetas[index].numeroTarjeta.charAt(13) +
                obj_tarjetas[index].numeroTarjeta.charAt(14) +
                obj_tarjetas[index].numeroTarjeta.charAt(15);

            // Se extrae el tipo de tarjeta.
            let tipoTarjeta = "";
            if (obj_tarjetas[index].tipo == "V") {
                tipoTarjeta = "Visa";
            } else {
                tipoTarjeta = "Mastercart";
            }

            // Se contruye la tabla.
            html +=
                `<tr>
                    <td>` + numeroTarjeta + `</td>
                    <td>` + tipoTarjeta + `</td>
                    <td>₡` + obj_tarjetas[index].monto + `</td>
                    <td>
                        <a href="#" onclick="eliminar_tarjeta('` + obj_tarjetas[index].id + `')">Eliminar tarjeta</a>
                    </td>
                </tr>`;

        }
        html += "</table>";
        document.getElementById("tarjetas_registradas").innerHTML = html;
    } else {
        document.getElementById("tarjetas_registradas").innerHTML =
            `
        <div class="alert alert-info" role="alert">
          No hay tarjetas registradas.
        </div>
        `;
    }
}

function eliminar_tarjeta(id) {

    Swal.fire({
        title: 'Eliminar tarjeta',
        text: "Esta accion no se puede deshacer. ¿Esta seguro/a?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar'
    }).then(async (result) => {
        if (result.value) {
            var json_request = {
                ID: id
            };
            fetch(API_URI_ELIMINAR + '/?ID=' + id, {
                method: 'delete'
            }).then(response =>
                response.json().then((json) => {
                    console.log(json);
                })
            );
            await Swal.fire(
                'Hecho',
                'La tarjeta ha sido eliminada.',
                'success'
            )
            cargar_tarjetas();
        }
    })
}

// Código para tablas a mostran en página de compras.

function cargar_tarjetasCompras() {
    fetch(API_URI)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let obj_tarjetas = JSON.parse(response);
            crearTablaDeTarjetas_compras(obj_tarjetas);
        })
        .catch(function (err) {
            console.error(err);
            document.getElementById("tarjetas_registradas").innerHTML =
                `<div class="alert alert-danger" role="alert">
                Ha ocurrido un error al intentar cargar las tarjetas.
            </div>`;
        });
}

function crearTablaDeTarjetas_compras(obj_tarjetas) {
    if (obj_tarjetas != null && obj_tarjetas.length > 0) {

        let html = "";

        html +=
            `
            <br>
            <div>
                Total de tarjetas: ${obj_tarjetas.length}
            </div>
            <br>
            <table class="table table-bordered">
                <tr>
                    <th scope="col">Número</th>
                    <th scope="col">Tipo</th>
                    <th scope="col">Saldo</th>
                    <th scope="col">Acción</th>
                </tr>
            `;
        for (let index = 0; index < obj_tarjetas.length; index++) {

            // Se extrae el numero de tarjeta.
            let numeroTarjeta = "xxxx" +
                obj_tarjetas[index].numeroTarjeta.charAt(12) +
                obj_tarjetas[index].numeroTarjeta.charAt(13) +
                obj_tarjetas[index].numeroTarjeta.charAt(14) +
                obj_tarjetas[index].numeroTarjeta.charAt(15);

            // Se extrae el tipo de tarjeta.
            let tipoTarjeta = "";
            if (obj_tarjetas[index].tipo == "V") {
                tipoTarjeta = "Visa";
            } else {
                tipoTarjeta = "Mastercart";
            }

            // Se contruye la tabla.
            html +=
                `<tr>
                    <td>` + numeroTarjeta + `</td>
                    <td>` + tipoTarjeta + `</td>
                    <td>₡` + obj_tarjetas[index].monto + `</td>
                    <td>
                        <a href="#" id="tarjetaOpcion${numeroTarjeta}" onclick="utilizarTarjeta('` + obj_tarjetas[index].id + `','tarjetaOpcion${numeroTarjeta}')">Utilizar esta tarjeta</a>
                    </td>
                </tr>`;
        }
        html += "</table>";
        document.getElementById("tabla_metodosDePago").innerHTML = html;
    } else {
        document.getElementById("tabla_metodosDePago").innerHTML =
            `
        <div class="alert alert-info" role="alert">
          No hay tarjetas registradas.
        </div>
        `;
    }
}

function utilizarTarjeta(id) {
    if (id != "") {
        var json_request = {
            metodoDePagoID: id
        };

        fetch(API_COMPRAMETODODEPAGO, {
            method: 'PUT',
            body: JSON.stringify(json_request),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .catch(error => console.error('Error:', error))
            .then((response) => {
                console.log('Success:', response);
                toggle_botonRealizarCompra(true);
            });
    } else {
        console.log("Datos vacios.");
    }
}
