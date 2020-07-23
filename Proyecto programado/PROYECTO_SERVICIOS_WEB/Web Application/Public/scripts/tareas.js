function guardarBitacora(admin, tipo, descripcion, registroEnDetalle) {
    var json_request = {
        "nombreUsuarioAdmin": admin,
        "codigoDelRegistro": "n/a",
        "tipo": tipo,
        "descripcion": descripcion,
        "registroEnDetalle": registroEnDetalle
    };

    const url = "https://localhost:44371/api/bitacora";

    fetch(url, {
        method: 'POST',
        body: JSON.stringify(json_request),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(res => res.json())
        .catch(error => console.error('Error:', error))
        .then((response) => {
            console.log('Success:', response)
        });
}
