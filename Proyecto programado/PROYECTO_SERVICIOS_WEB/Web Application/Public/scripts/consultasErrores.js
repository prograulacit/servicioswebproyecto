const apiURL = "https://localhost:44371";

function cargar_errores(fechaInicio, fechaFinal) {
    let tablaErrores = document.getElementById("tabla_errores");
    tablaErrores.innerHTML = "** Cargando datos..."
    fetch(`${apiURL}/api/error`)
        .then(function (response) { return response.text(); })
        .then(function (response) {
            let json = JSON.parse(response);
            if (json != null) {
                // Aplica filtros
                if (fechaInicio) {
                    json = filtro_fecha_inicio(json, 'fechaYHora', fechaInicio);
                }
                if (fechaFinal) {
                    json = filtro_fecha_final(json, 'fechaYHora', fechaFinal);
                }

                // Genera tabla
                let html = "";
                html += `<table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Numero de error</th>
                                <th>Fecha y Hora</th>
                                <th>Mensaje de error</th>
                            </tr>
                        </thead>
                        <tbody>`;
                for (let index = 0; index < json.length; index++) {
                    html += `<tr>
                            <td>${json[index].id}</td>
                            <td>${json[index].fechaYHora}</td>
                            <td>${json[index].mensajeDeError}</td>
                        </tr>`;
                }
                html += "</tbody></table>";
                tablaErrores.innerHTML = html;
            } else {
                tablaErrores.innerHTML = "No hay registros de errores.";
            }
        })
        .catch(function (err) {
            console.error(err);
            tablaErrores.innerHTML = "*** Ha ocurrido un error";
        });
}

function button_submit_errores_buscar() {
    let inputErroresFechaInicio = document.getElementById("input_errores_fecha_inicio");
    let inputErroresFechaFinal = document.getElementById("input_errores_fecha_final");
    cargar_errores(inputErroresFechaInicio.value, inputErroresFechaFinal.value)
}