const apiURL = "https://localhost:44371";

function get_data_filtrada(array, llave, data_filtro) {
    let filtrado = array.filter((item) => {
        return Object.keys(item).some((key) => item[llave].includes(data_filtro));
    });
    return filtrado;
}

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
                        break;
                        case 'semanal':
                        break;
                        case 'mensualActual':
                        break;
                        case 'mensualAnterior':
                        break;
                        case 'trimestral':
                        break;
                        case 'semestral':
                        break;
                        case 'anual':
                        break;
                        case 'rango':
                            if (fechaInicio) {
                                json = json.filter((item) => {
                                    const fecha1 = new Date(item['fechaCompra']);
                                    const fecha2 = new Date(fechaInicio);
                                    fecha1.setHours(0, 0, 0, 0);
                                    fecha2.setHours(0, 0, 0, 0);
                                    return fecha1.getTime() >= fecha2.getTime();
                                });
                            };
                            if (fechaFinal) {
                                json = json.filter((item) => {
                                    const fecha1 = new Date(item['fechaCompra']);
                                    const fecha2 = new Date(fechaFinal);
                                    fecha1.setHours(0, 0, 0, 0);
                                    fecha2.setHours(0, 0, 0, 0);
                                    return fecha1.getTime() <= fecha2.getTime();
                                });
                            };
                        break;
                    }
                }
                //if (medioPago) {
                //    json = get_data_filtrada(json, 'medioPago', medioPago);
                //}

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
                tablaTransacciones.innerHTML = "No hay registros de errores.";
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