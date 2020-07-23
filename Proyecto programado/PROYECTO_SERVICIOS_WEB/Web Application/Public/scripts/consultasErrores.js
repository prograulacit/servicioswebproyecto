const apiURL = "https://localhost:44371";

function get_data_filtrada(array, llave, data_filtro) {
    let filtrado = array.filter((item) => {
        return Object.keys(item).some((key) => item[llave].includes(data_filtro));
    });
    return filtrado;
}

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
                    json = json.filter((item) => {
                        const fecha1 = new Date(item['fechaYHora']);
                        const fecha2 = new Date(fechaInicio);
                        fecha1.setHours(0, 0, 0, 0);
                        fecha2.setHours(0, 0, 0, 0);
                        return fecha1.getTime() >= fecha2.getTime();
                    });
                }
                if (fechaFinal) {
                    json = json.filter((item) => {
                        const fecha1 = new Date(item['fechaYHora']);
                        const fecha2 = new Date(fechaFinal);
                        fecha1.setHours(0, 0, 0, 0);
                        fecha2.setHours(0, 0, 0, 0);
                        return fecha1.getTime() <= fecha2.getTime();
                    });
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