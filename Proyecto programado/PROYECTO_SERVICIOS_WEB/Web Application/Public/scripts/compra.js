const tabla_metodosDePago = document.getElementById("tabla_metodosDePago");

function seleccion_tarjeta() {
    selector_contenidoTarjeta();
    cargar_tarjetasCompras();
}

function seleccion_easypay() {
    selector_contenidoEasyPay();
    cargar_easypays_compras();
}

// Establece en el navegador de tipo de pago a Tarjeta como metodo de pago.
function selector_contenidoTarjeta() {
    let contenido =
    `
    <ul class="nav nav-pills">
        <li class="nav-item">
            <a onclick="seleccion_tarjeta()" class="nav-link active" href="#">Tarjeta</a>
        </li>
        <li class="nav-item">
            <a onclick="seleccion_easypay()" class="nav-link" href="#">EasyPay</a>
        </li>
    </ul>
    `;

    document.getElementById('selector_metodoDePago').innerHTML = contenido;
}

// Establece en el navegador de tipo de pago a EasyPay como metodo de pago.
function selector_contenidoEasyPay() {
    let contenido =
    `
    <ul class="nav nav-pills">
        <li class="nav-item">
            <a onclick="seleccion_tarjeta()" class="nav-link" href="#">Tarjeta</a>
        </li>
        <li class="nav-item">
            <a onclick="seleccion_easypay()" class="nav-link active" href="#">EasyPay</a>
        </li>
    </ul>
    `;

    document.getElementById('selector_metodoDePago').innerHTML = contenido;
}