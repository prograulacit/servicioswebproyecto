const apiURL = "https://localhost:44371";

function cargar_descargas(nombreProducto, tipoFecha, fechaInicio, fechaFinal, tipo) {
    let tablaDescargas = document.getElementById("tabla_descargas");
    tablaDescargas.innerHTML = "** Cargando datos..."
    fetch(`${apiURL}/api/descargas`)
        .then(function (response) { return response.text(); })
        .then(function (response) {
            let json = JSON.parse(response);
            if (json != null) {
                // Aplica filtros
                if (tipoFecha) {
                    switch (tipoFecha) {
                        case 'diaria':
                            json = filtro_fecha_actual_diaria(json, 'fechaYHora');
                            break;
                        case 'semanal':
                            json = filtro_fecha_actual_semanal(json, 'fechaYHora');
                            break;
                        case 'mensualActual':
                            json = filtro_fecha_actual_mensual_actual(json, 'fechaYHora');
                            break;
                        case 'mensualAnterior':
                            json = filtro_fecha_actual_mensual_anterior(json, 'fechaYHora');
                            break;
                        case 'trimestral':
                            json = filtro_fecha_actual_trimestral(json, 'fechaYHora');
                            break;
                        case 'semestral':
                            json = filtro_fecha_actual_semestral(json, 'fechaYHora');
                            break;
                        case 'anual':
                            json = filtro_fecha_actual_anual(json, 'fechaYHora');
                            break;
                        case 'rango':
                            if (fechaInicio) {
                                json = filtro_fecha_inicio(json, 'fechaYHora', fechaInicio);
                            };
                            if (fechaFinal) {
                                json = filtro_fecha_final(json, 'fechaYHora', fechaFinal);
                            };
                            break;
                    }
                }
                if (nombreProducto) {
                    json = get_data_filtrada(json, 'nombre', nombreProducto);
                }
                if (tipo) {
                    json = get_data_filtrada(json, 'tipo', tipo);
                }

                // Genera tabla
                let html = "";
                html += `<table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Nombre de descarga</th>
                                <th>Fecha</th>
                                <th>Cantidad de descargas</th>
                            </tr>
                        </thead>
                        <tbody>`;
                for (let index = 0; index < json.length; index++) {
                    html += `<tr>
                            <td>${json[index].nombre}</td>
                            <td>${json[index].fechaYHora}</td>
                            <td>${json[index].cantidad}</td>
                        </tr>`;
                }
                html += "</tbody></table>";
                tablaDescargas.innerHTML = html;
            } else {
                tablaDescargas.innerHTML = "No hay registros de descargas.";
            }
        })
        .catch(function (err) {
            console.error(err);
            tablaDescargas.innerHTML = "*** Ha ocurrido un error";
        });
}

function button_submit_descargas_buscar() {
    let inputDescargasNombre = document.getElementById("input_descargas_nombre");
    let inputDescargasTipo = document.getElementById("input_descargas_tipo");
    let inputDescargasTipoFecha = document.getElementById("input_descargas_tipo_fecha");
    let inputDescargasInicioFecha = document.getElementById("input_descargas_inicio_fecha");
    let inputDescargasFinalFecha = document.getElementById("input_descargas_final_fecha");
    cargar_descargas(inputDescargasNombre.value, inputDescargasTipoFecha.value, inputDescargasInicioFecha.value, inputDescargasFinalFecha.value, inputDescargasTipo.value);
}

function tipo_descarga_cambio() {
    let inputDescargasTipoFecha = document.getElementById("input_descargas_tipo_fecha");
    let inputDescargasInicioFecha = document.getElementById("input_descargas_inicio_fecha");
    let inputDescargasFinalFecha = document.getElementById("input_descargas_final_fecha");

    if (inputDescargasTipoFecha.value === 'rango') {
        inputDescargasInicioFecha.style.display = "block";
        inputDescargasFinalFecha.style.display = "block";
    } else {
        inputDescargasInicioFecha.style.display = "none";
        inputDescargasFinalFecha.style.display = "none";
        inputDescargasInicioFecha.value = null;
        inputDescargasFinalFecha.value = null;
    }
}