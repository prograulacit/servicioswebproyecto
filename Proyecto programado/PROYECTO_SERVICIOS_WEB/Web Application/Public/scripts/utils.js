function get_data_filtrada(array, llave, data_filtro) {
    let filtrado = array.filter((item) => {
        return Object.keys(item).some((key) => item[llave].includes(data_filtro));
    });
    return filtrado;
}

function filtro_fecha_inicio(array, columna, fecha) {
    let resultado = array.filter((item) => {
        const fecha1 = new Date(item[columna]);
        const fecha2 = new Date(fecha);
        fecha1.setHours(0, 0, 0, 0);
        fecha2.setHours(0, 0, 0, 0);
        return fecha1.getTime() >= fecha2.getTime();
    });
    return resultado;
}

function filtro_fecha_final(array, columna, fecha) {
    let resultado = array.filter((item) => {
        const fecha1 = new Date(item[columna]);
        const fecha2 = new Date(fecha);
        fecha1.setHours(0, 0, 0, 0);
        fecha2.setHours(0, 0, 0, 0);
        return fecha1.getTime() <= fecha2.getTime();
    });
    return resultado;
}

function filtro_fecha_actual_diaria(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const fecha1 = new Date(item[columna]);
        return fecha1.getDay() === today.getDay();
    });
    return resultado;
}

function filtro_fecha_actual_semanal(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const fecha1 = new Date(item[columna]);
        return fecha1.getDay() >= (today.getDay()-7) && fecha1.getDay() <= today.getDay();
    });
    return resultado;
}

function filtro_fecha_actual_mensual_actual(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const fecha1 = new Date(item[columna]);
        return fecha1.getMonth() === today.getMonth();
    });
    return resultado;
}

function filtro_fecha_actual_mensual_anterior(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const fecha1 = new Date(item[columna]);
        return fecha1.getMonth() === (today.getMonth() - 1);
    });
    return resultado;
}

function filtro_fecha_actual_trimestral(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const fecha1 = new Date(item[columna]);
        return (fecha1.getMonth() === today.getMonth()) || (fecha1.getMonth() === today.getMonth() - 1) || (fecha1.getMonth() === today.getMonth() - 2);
    });
    return resultado;
}

function filtro_fecha_actual_semestral(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const fecha1 = new Date(item[columna]);
        return (fecha1.getMonth() === today.getMonth()) || (fecha1.getMonth() === today.getMonth() - 1) || (fecha1.getMonth() === today.getMonth() - 2) ||
            (fecha1.getMonth() === today.getMonth() - 3) || (fecha1.getMonth() === today.getMonth() - 4) || (fecha1.getMonth() === today.getMonth() - 5);
    });
    return resultado;
}

function filtro_fecha_actual_anual(array, columna) {
    let resultado = array.filter((item) => {
        const today = new Date();
        const fecha1 = new Date(item[columna]);
        return fecha1.getFullYear() === today.getFullYear();
    });
    return resultado;
}