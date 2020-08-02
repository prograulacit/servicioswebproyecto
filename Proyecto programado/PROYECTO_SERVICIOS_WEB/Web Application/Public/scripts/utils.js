function get_data_filtrada(array, llave, data_filtro) {
    let filtrado = array.filter((item) => {
        return Object.keys(item).some((key) => item[llave].includes(data_filtro));
    });
    return filtrado;
}

function filtro_fecha_inicio(array, columna, fecha) {
    const viejaFecha = fecha.split("/");
    const nuevaFecha = viejaFecha.join("-");
    const fechaInput = new Date(`${nuevaFecha} 00:00`);
    fechaInput.setHours(0, 0, 0, 0);

    let resultado = array.filter((item) => {
        const viejaFechaItem = (item[columna]).split(" ");
        const nuevaFechaItem = `${viejaFechaItem[0]}  00:00`;

        console.log("fecha tabla raw: " + nuevaFechaItem)
        const fechaItem = new Date(nuevaFechaItem);
        fechaItem.setHours(0, 0, 0, 0);
        return fechaItem.getDate() >= fechaInput.getDate();
    });
    return resultado;
}

function filtro_fecha_final(array, columna, fecha) {
    const viejaFecha = fecha.split("/");
    const nuevaFecha = viejaFecha.join("-");
    const fechaInput = new Date(`${nuevaFecha} 00:00`);
    fechaInput.setHours(0, 0, 0, 0);

    let resultado = array.filter((item) => {
        const viejaFechaItem = (item[columna]).split(" ");
        const nuevaFechaItem = `${viejaFechaItem[0]}  00:00`;
        const fechaItem = new Date(nuevaFechaItem);
        fechaItem.setHours(0, 0, 0, 0);
        return fechaItem.getDate() <= fechaInput.getDate();
    });
    return resultado;
}

function filtro_fecha_actual_diaria(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const viejaFechaItem = (item[columna]).split(" ");
        const nuevaFechaItem = `${viejaFechaItem[0]}  00:00`;
        const fechaItem = new Date(nuevaFechaItem);
        return fechaItem.getDay() === today.getDay();
    });
    return resultado;
}

function filtro_fecha_actual_semanal(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const viejaFechaItem = (item[columna]).split(" ");
        const nuevaFechaItem = `${viejaFechaItem[0]}  00:00`;
        const fechaItem = new Date(nuevaFechaItem);
        return fechaItem.getDay() >= (today.getDay() - 7) && fechaItem.getDay() <= today.getDay();
    });
    return resultado;
}

function filtro_fecha_actual_mensual_actual(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const viejaFechaItem = (item[columna]).split(" ");
        const nuevaFechaItem = `${viejaFechaItem[0]}  00:00`;
        const fechaItem = new Date(nuevaFechaItem);
        return fechaItem.getMonth() === today.getMonth();
    });
    return resultado;
}

function filtro_fecha_actual_mensual_anterior(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const viejaFechaItem = (item[columna]).split(" ");
        const nuevaFechaItem = `${viejaFechaItem[0]}  00:00`;
        const fechaItem = new Date(nuevaFechaItem);
        return fechaItem.getMonth() === (today.getMonth() - 1);
    });
    return resultado;
}

function filtro_fecha_actual_trimestral(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const viejaFechaItem = (item[columna]).split(" ");
        const nuevaFechaItem = `${viejaFechaItem[0]}  00:00`;
        const fechaItem = new Date(nuevaFechaItem);
        return (fechaItem.getMonth() === today.getMonth()) || (fechaItem.getMonth() === today.getMonth() - 1) || (fechaItem.getMonth() === today.getMonth() - 2);
    });
    return resultado;
}

function filtro_fecha_actual_semestral(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const viejaFechaItem = (item[columna]).split(" ");
        const nuevaFechaItem = `${viejaFechaItem[0]}  00:00`;
        const fechaItem = new Date(nuevaFechaItem);
        return (fechaItem.getMonth() === today.getMonth()) || (fechaItem.getMonth() === today.getMonth() - 1) || (fechaItem.getMonth() === today.getMonth() - 2) ||
            (fechaItem.getMonth() === today.getMonth() - 3) || (fechaItem.getMonth() === today.getMonth() - 4) || (fechaItem.getMonth() === today.getMonth() - 5);
    });
    return resultado;
}

function filtro_fecha_actual_anual(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const viejaFechaItem = (item[columna]).split(" ");
        const nuevaFechaItem = `${viejaFechaItem[0]}  00:00`;
        const fechaItem = new Date(nuevaFechaItem);
        return fechaItem.getFullYear() === today.getFullYear();
    });
    return resultado;
}