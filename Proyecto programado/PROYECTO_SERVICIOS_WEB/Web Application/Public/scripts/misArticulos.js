const apiURL = "https://localhost:44371";

function traer_descarga(nombreArchivo) {
    fetch(`${apiURL}/api/Descargas/?archivoDescarga=${nombreArchivo}`, {
        responseType: "arraybuffer"
    })
        .then(function (response) {
            return response.blob();
        })
        .then(function (response) {
            const url = window.URL.createObjectURL(response);
            const a = document.createElement('a');
            a.style.display = 'none';
            a.href = url;
            a.download = nombreArchivo;
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
        })
        .catch(function (err) {
            console.error(err);
        });
}

function cargar_articulos(idUsuario) {
    let tablaArticulos = document.getElementById("tabla_articulos");
    tablaArticulos.innerHTML = "** Cargando datos..."
    fetch(`${apiURL}/api/Transaccion?idUsuario=${idUsuario}`)
        .then(function (response) { return response.text(); })
        .then(function (response) {
            let json = JSON.parse(response);
            if (json != null) {

                // Genera tabla
                let html = "";
                html += `<table class="table table-bordered">
                        <thead class="thead-dark">
                            <tr>
                                <th>Nombre producto</th>
                                <th>Codigo</th>
                                <th>Fecha compra</th>
                                <th>Monto</th>
                            </tr>
                        </thead>
                        <tbody>`;
                for (let index = 0; index < json.length; index++) {
                    let producto = JSON.parse(json[index].consecutivoProductoID);
                    html += `<tr>
                            <td>${producto.nombre}</td>
                            <td>${producto.id}</td>
                            <td>${json[index].fechaCompra}</td>
                            <td>$${json[index].monto}</td>
                            <td><a href="#" onclick="traer_descarga('${producto.nombreArchivoDescarga}')">Descargar</a></td>
                        </tr>`;
                }
                html += "</tbody></table>";
                tablaArticulos.innerHTML = html;
            } else {
                tablaArticulos.innerHTML = "No hay registros de libros.";
            }
        })
        .catch(function (err) {
            console.error(err);
            tablaArticulos.innerHTML = "*** Ha ocurrido un error";
        });
}