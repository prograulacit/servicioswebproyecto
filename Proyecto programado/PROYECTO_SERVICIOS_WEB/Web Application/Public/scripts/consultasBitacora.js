const apiURL = "https://localhost:44371";

function get_data_filtrada(array, llave, data_filtro) {
    let filtrado = array.filter((item) => {
        return Object.keys(item).some((key) => item[llave].includes(data_filtro));
    });
    return filtrado;
}

function cargar_bitacora(nombreUsuarioAdmin, fechaInicio, fechaFinal, tipo) {
    let tablaBitacora = document.getElementById("tabla_bitacora");
    tablaBitacora.innerHTML = "** Cargando datos..."
    fetch(`${apiURL}/api/bitacora`)
        .then(function (response) { return response.text(); })
        .then(function (response) {
            let json = JSON.parse(response);
            if (json != null) {
                // Aplica filtros
                if (nombreUsuarioAdmin) {
                    json = get_data_filtrada(json, 'nombreUsuarioAdmin', nombreUsuarioAdmin);
                }
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
                if (tipo) {
                    json = get_data_filtrada(json, 'tipo', tipo);
                }

                // Genera tabla
                let html = "";
                html += `<table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Codigo</th>
                                <th>Fecha y Hora</th>
                                <th>Descripcion</th>
                                <th>Detalle</th>
                            </tr>
                        </thead>
                        <tbody>`;
                for (let index = 0; index < json.length; index++) {
                    html += `<tr>
                            <td>${json[index].id}</td>
                            <td>${json[index].fechaYHora}</td>
                            <td>${json[index].descripcion}</td>
                            <td><a href="/${json[index].registroEnDetalle}">Ver</a></td>
                        </tr>`;
                }
                html += "</tbody></table>";
                tablaBitacora.innerHTML = html;
            } else {
                tablaBitacora.innerHTML = "No hay registros de bitacora.";
            }
        })
        .catch(function (err) {
            console.error(err);
            tablaBitacora.innerHTML = "*** Ha ocurrido un error";
        });
}

function button_submit_bitacora_buscar() {
    let inputBitacoraUsuario = document.getElementById("input_bitacora_usuario");
    let inputBitacoraFechaInicio = document.getElementById("input_bitacora_fecha_inicio");
    let inputBitacoraFechaFinal = document.getElementById("input_bitacora_fecha_final");
    let inputBitacoraTipo = document.getElementById("input_bitacora_tipo");
    cargar_bitacora(inputBitacoraUsuario.value, inputBitacoraFechaInicio.value, inputBitacoraFechaFinal.value, inputBitacoraTipo.value)
}