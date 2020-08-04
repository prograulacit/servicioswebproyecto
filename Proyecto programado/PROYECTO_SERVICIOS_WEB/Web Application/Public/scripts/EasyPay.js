﻿const API_URI_EASYPAY = "https://localhost:44371/api/easypay?user_id=asociada";
const API_URI_ELIMINAR_EASYPAY = "https://localhost:44371/api/easypay";

function cargar_easypays() {
    fetch(API_URI_EASYPAY)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let obj_easypays = JSON.parse(response);
            crearTablaDeEasyPays(obj_easypays);
        })
        .catch(function (err) {
            console.error(err);
            document.getElementById("tarjetas_registradas").innerHTML =
                `<div class="alert alert-danger" role="alert">
                Ha ocurrido un error al intentar cargar los EasyPays.
            </div>`;
        });
}

function crearTablaDeEasyPays(obj_easypays) {
    if (obj_easypays != null && obj_easypays.length > 0) {

        let html = "";

        html +=
            `
            <div class="subtitulo">
                Cuentas EasyPay registradas
            </div>
            <div>
                Total de cuentas: ${obj_easypays.length}
            </div>
            <br>
            <table class="table table-bordered">
                <tr>
                    <th scope="col">Tarjeta</th>
                    <th scope="col">Código seguridad</th>
                    <th scope="col">Saldo</th>
                    <th scope="col">Accion</th>
                </tr>
            `;
        for (let index = 0; index < obj_easypays.length; index++) {

            // Se contruye la tabla.
            html +=
                `<tr>
                    <td>${obj_easypays[index].numeroCuenta}</td>
                    <td>${obj_easypays[index].codigoSeguridad}</td>
                    <td>${obj_easypays[index].monto}</td>
                    <td>
                        <a href="#" onclick="editar_easypay('${obj_easypays[index].id}')">Editar</a>
                        <a href="#" onclick="eliminar_easypay('${obj_easypays[index].id}')">Eliminar</a>
                    </td>
                </tr>`;

        }
        html += "</table>";
        document.getElementById("tabla_easypays").innerHTML = html;
    } else {
        document.getElementById("tabla_easypays").innerHTML =
            `
            <div class="alert alert-info" role="alert">
              No hay cuentas EasyPay registradas.
            </div>
            `;
    }
}

function eliminar_easypay(id) {

    Swal.fire({
        title: 'Eliminar EasyPay',
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
            fetch(API_URI_ELIMINAR_EASYPAY + '/?ID=' + id, {
                method: 'delete'
            }).then(response =>
                response.json().then((json) => {
                    console.log(json);
                })
            );
            await Swal.fire(
                'Hecho',
                'La cuenta EasyPay ha sido eliminada.',
                'success'
            )
            cargar_easypays();
        }
    })
}


function cargarTarjetas_easypay() {
    fetch(API_URI)
        .then(function (response) {
            return response.text();
        })
        .then(function (response) {
            let obj_tarjetas = JSON.parse(response);
            crearTablaTarjetas_easypay(obj_tarjetas);
        })
        .catch(function (err) {
            console.error(err);
            document.getElementById("tarjetas_registradas").innerHTML =
                `<div class="alert alert-danger" role="alert">
                Ha ocurrido un error al intentar cargar las tarjetas.
            </div>`;
        });
}

function crearTablaTarjetas_easypay(obj_tarjetas) {
    if (obj_tarjetas != null && obj_tarjetas.length > 0) {

        let html = "";

        html +=
            `
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
                    <td>` + obj_tarjetas[index].monto + `</td>
                    <td>
                        <a href="#/" onclick="utilizarTarjeta_easypay('` + obj_tarjetas[index].id + `')">Seleccionar</a>
                    </td>
                </tr>`;

        }
        html += "</table>";
        document.getElementById("tablaTarjetas_easypay").innerHTML = html;
    } else {
        document.getElementById("tablaTarjetas_easypay").innerHTML =
            `
        <div class="alert alert-info" role="alert">
          No hay tarjetas registradas.
        </div>
        `;
    }
}


function utilizarTarjeta_easypay(id) {
    document.getElementById('ContentPlaceHolder1_Label_tarjetaAUtilizar').innerHTML = id;
}