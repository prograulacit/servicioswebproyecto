const apiURL = "https://localhost:44371";

function cargar_transacciones(tipoFecha, fechaInicio, fechaFinal, medioPago) {
    let tablaTransacciones = document.getElementById("tabla_transacciones");
    tablaTransacciones.innerHTML = "** Cargando datos..."
    fetch(`${apiURL}/api/transaccion`)
        .then(function (response) { return response.text(); })
        .then(function (response) {
            let json = JSON.parse(response);
            if (json != null) {
                // Aplica filtros
                if (tipoFecha) {
                    switch (tipoFecha) {
                        case 'diaria':
                            json = filtro_fecha_actual_diaria(json, 'fechaCompra');
                        break;
                        case 'semanal':
                            json = filtro_fecha_actual_semanal(json, 'fechaCompra');
                        break;
                        case 'mensualActual':
                            json = filtro_fecha_actual_mensual_actual(json, 'fechaCompra');
                        break;
                        case 'mensualAnterior':
                            json = filtro_fecha_actual_mensual_anterior(json, 'fechaCompra');
                        break;
                        case 'trimestral':
                            json = filtro_fecha_actual_trimestral(json, 'fechaCompra');
                        break;
                        case 'semestral':
                            json = filtro_fecha_actual_semestral(json, 'fechaCompra');
                        break;
                        case 'anual':
                            json = filtro_fecha_actual_anual(json, 'fechaCompra');
                        break;
                        case 'rango':
                            if (fechaInicio) {
                                json = filtro_fecha_inicio(json, 'fechaCompra', fechaInicio);
                            };
                            if (fechaFinal) {
                                json = filtro_fecha_final(json, 'fechaCompra', fechaFinal);
                            };
                        break;
                    }
                }
                if (medioPago) {
                    switch (medioPago) {
                        case 'tarjeta':
                            json = json.filter((item) => {
                                return item['tarjetaID'] !== null;
                            });
                            break;
                        case 'easypay':
                            json = json.filter((item) => {
                                return item['easyPayID'] !== null;
                            });
                            break;
                        case 'ambas':
                            json = json.filter((item) => {
                                return item['tarjetaID'] !== null && item['easyPayID'] !== null;
                            });
                            break;
                    }
                }

                // Genera tabla
                let html = "";
                html += `<table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Numero</th>
                                <th>Fecha</th>
                                <th>Monto</th>
                            </tr>
                        </thead>
                        <tbody>`;
                for (let index = 0; index < json.length; index++) {
                    html += `<tr>
                            <td>${json[index].id}</td>
                            <td>${json[index].fechaCompra}</td>
                            <td>${json[index].monto}</td>
                        </tr>`;
                }
                html += "</tbody></table>";
                tablaTransacciones.innerHTML = html;
            } else {
                tablaTransacciones.innerHTML = "No hay registros de transacciones.";
            }
        })
        .catch(function (err) {
            console.error(err);
            tablaTransacciones.innerHTML = "*** Ha ocurrido un error";
        });
}

function button_submit_transacciones_buscar() {
    let inputTransaccionesTipoFecha = document.getElementById("input_transacciones_tipo_fecha");
    let inputTransaccionesInicioFecha = document.getElementById("input_transacciones_inicio_fecha");
    let inputTransaccionesFinalFecha = document.getElementById("input_transacciones_final_fecha");
    let inputTransaccionesMedioPago = document.getElementById("input_transacciones_medio_pago");
    cargar_transacciones(inputTransaccionesTipoFecha.value, inputTransaccionesInicioFecha.value, inputTransaccionesFinalFecha.value, inputTransaccionesMedioPago.value)
}

function tipo_transaccion_cambio() {
    let inputTransaccionesTipoFecha = document.getElementById("input_transacciones_tipo_fecha");
    let inputTransaccionesInicioFecha = document.getElementById("input_transacciones_inicio_fecha");
    let inputTransaccionesFinalFecha = document.getElementById("input_transacciones_final_fecha");

    if (inputTransaccionesTipoFecha.value === 'rango') {
        inputTransaccionesInicioFecha.style.display = "block";
        inputTransaccionesFinalFecha.style.display = "block";
    } else {
        inputTransaccionesInicioFecha.style.display = "none";
        inputTransaccionesFinalFecha.style.display = "none";
        inputTransaccionesInicioFecha.value = null;
        inputTransaccionesFinalFecha.value = null;
    }
}