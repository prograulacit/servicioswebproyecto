const tabla_metodosDePago = document.getElementById("tabla_metodosDePago");
const botonCompra_contenedor = document.getElementById("botonCompra_contenedor");

function seleccion_tarjeta() {
    selector_contenidoTarjeta();
    cargar_tarjetasCompras();
    toggle_botonRealizarCompra(false); // Oculta el boton Realizar compra.
}

function seleccion_easypay() {
    selector_contenidoEasyPay();
    cargar_easypays_compras();
    toggle_botonRealizarCompra(false); // Oculta el boton Realizar compra.
}

// Establece en el interfaz el selector de Tarjeta como metodo de pago.
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

// Establece en el interfaz el selector de EasyPays como metodo de pago.
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

// Hace visible o invisible el contenedor de botón compra.
function toggle_botonRealizarCompra(status) {
    
    if (status) {
        botonCompra_contenedor.style.display = "inline";

        // Muestra mensaje de que se ha establecido el metodo de
        // pago.
        Toast.fire({
            icon: 'success',
            title: 'Método de pago establecido'
        })
    } else {
        botonCompra_contenedor.style.display = "none";
    }
}

// Envia al usuario al menu de checkout donde su compra es realizada.
function realizarCompra() {
    window.location.href =
        "https://localhost:44371/Paginas/Frontend/checkout.aspx";
}

// Muestra un mensaje de SweetAlert en una esquina.
const Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 1300,
    timerProgressBar: true,
    onOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
})
