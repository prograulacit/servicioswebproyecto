// Este script lleva a cabo la logica para comprar productos.

const URL_PRODUCTOACOMPRAR = "https://localhost:44371/";

function establecerProductoAComprar(id) {
    if (id != "") {
        var json_request = {
            productoCompraId: id
        };

        fetch(URL_PRODUCTOACOMPRAR + "api/ProductoCompra", {
            method: 'PUT',
            body: JSON.stringify(json_request),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .catch(error => console.error('Error:', error))
            .then( async(response) => {
                await console.log('Success:', response);
                window.location.href = "https://localhost:44371/Paginas/Frontend/Compra.aspx";
            });
    } else {
        console.log("Datos vacios.");
    }
}