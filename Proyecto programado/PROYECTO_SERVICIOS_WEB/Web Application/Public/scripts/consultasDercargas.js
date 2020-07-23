const apiURL = "https://localhost:44371";

function get_data_filtrada(array, llave, data_filtro) {
    let filtrado = array.filter((item) => {
        return Object.keys(item).some((key) => item[llave].includes(data_filtro));
    });
    return filtrado;
}

function cargar_descargas(tipoFecha, fechaInicio, fechaFinal, tipo, categoria) {
    let tablaDescargas = document.getElementById("tabla_descargas");
    tablaDescargas.innerHTML = "** Cargando datos..."
    fetch(`${apiURL}/api/descarga`)
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
                                <th>Nombre de descarga</th>
                                <th>Cantidad de descargas</th>
                            </tr>
                        </thead>
                        <tbody>`;
                for (let index = 0; index < json.length; index++) {
                    html += `<tr>
                            <td>${json[index].id}</td>
                            <td>${json[index].fechaCompra}</td>
                        </tr>`;
                }
                html += "</tbody></table>";
                tablaDescargas.innerHTML = html;
            } else {
                tablaDescargas.innerHTML = "No hay registros de errores.";
            }
        })
        .catch(function (err) {
            console.error(err);
            tablaDescargas.innerHTML = "*** Ha ocurrido un error";
        });
}

function button_submit_descargas_buscar() {
    let inputDescargasTipoFecha = document.getElementById("input_descargas_tipo_fecha");
    let inputDescargasInicioFecha = document.getElementById("input_descargas_inicio_fecha");
    let inputDescargasFinalFecha = document.getElementById("input_descargas_final_fecha");
    let inputDescargasTipo = document.getElementById("input_descargas_tipo");
    let inputDescargasCategoria = document.getElementById("input_descargas_categoria");
    cargar_descargas(inputDescargasTipoFecha.value, inputDescargasInicioFecha.value, inputDescargasFinalFecha.value, inputDescargasTipo.value, inputDescargasCategoria.value)
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