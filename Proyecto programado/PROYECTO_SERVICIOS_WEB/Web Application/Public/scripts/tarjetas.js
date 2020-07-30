const elemento_verTarjetasRegistradas = document.getElementById("verTarjetasRegistradas");
const elemento_crearNuevaTarjeta = document.getElementById("crearNuevaTarjeta");

verTarjetasRegistradas();

function crearNuevaTarjeta() {
    

    elemento_crearNuevaTarjeta.style.display = "inline";
    elemento_verTarjetasRegistradas.style.display = "none";
}

function verTarjetasRegistradas() {
    elemento_crearNuevaTarjeta.style.display = "none";
    elemento_verTarjetasRegistradas.style.display = "inline";
}