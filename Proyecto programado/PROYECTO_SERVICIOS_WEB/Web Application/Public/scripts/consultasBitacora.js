const apiURL = "https://localhost:44371";

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
                    json = filtro_fecha_inicio(json, 'fechaYHora', fechaInicio);
                }
                if (fechaFinal) {
                    json = filtro_fecha_final(json, 'fechaYHora', fechaFinal);
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