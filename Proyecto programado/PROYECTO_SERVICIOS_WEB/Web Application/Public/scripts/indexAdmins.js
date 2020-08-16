// Botones de navegador.
const navegador_seguridad = document.getElementById("navegador_seguridad");
const navegador_administracionProductos =
    document.getElementById("navegador_administracionProductos");
const navegador_consultas = document.getElementById("navegador_consultas");

const card_body = document.getElementById("card_body");

// Acciones de botones de navegador.
navegador_seguridad.addEventListener('click', () => {
    navegador_seguridad.classList.add('active');
    navegador_administracionProductos.classList.remove('active');
    navegador_consultas.classList.remove('active');
    renderizarContenido_seguridad();
});

// Acciones de botones de navegador.
navegador_administracionProductos.addEventListener('click', () => {
    navegador_seguridad.classList.remove('active');
    navegador_administracionProductos.classList.add('active');
    navegador_consultas.classList.remove('active');
    renderizarContenido_administracion();
});

// Acciones de botones de navegador.
navegador_consultas.addEventListener('click', () => {
    navegador_seguridad.classList.remove('active');
    navegador_administracionProductos.classList.remove('active');
    navegador_consultas.classList.add('active');
    renderizarContenido_consultas();
});

/////////////////////////////////////////////////
// Funciones de renderización de contenido.
/////////////////////////////////////////////////

function renderizarContenido_seguridad() {
    let contenido = `
        <div class="subtitulo">
            Cree y edite la información de otros administadores o la suya.
        </div>
        <a class="btn btn-light" href="./crearNuevoAdmin.aspx">Crear nuevo administrador</a>
        <br>
        <a class="btn btn-light" href="./editarAdministradores.aspx">Editar administradores</a>
        <br>
        <a class="btn btn-light" href="./cambiarContrasenia.aspx">Cambiar contraseña actual</a>
        `;
    card_body.innerHTML = contenido; // Asigna el contenido al ID card_body.
}

function renderizarContenido_administracion() {
    let contenido = `
        <div class="subtitulo">
            Crear nuevos productos; y nuevas categorias y cambie su información referente al servidor.
        </div>
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-3"></div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-3">
                <a class="btn btn-light" href="generosPeliculas.aspx">Generos de peliculas.</a>
                <br>
                <a class="btn btn-light" href="generosMusica.aspx">Generos de musica.</a>
                <br>
                <a class="btn btn-light" href="categoriasLibro.aspx">Categorias de libro.</a>
                <br>
                <a class="btn btn-light" href="consecutivos.aspx">Consecutivos.</a>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-3">
                <a class="btn btn-light" href="parametros.aspx">Parámetros</a>
                <br>
                <a class="btn btn-light" href="peliculasAdmin.aspx">Películas</a>
                <br>
                <a class="btn btn-light" href="libroAdmin.aspx">Libros</a>
                <br>
                <a class="btn btn-light" href="musicaAdmin.aspx">Música</a>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-3"></div>
        </div>
             `;
    card_body.innerHTML = contenido; // Asigna el contenido al ID card_body.
}

function renderizarContenido_consultas() {
    let contenido = `
        <div class="subtitulo">
            Consulte la bitacora guardada en el sistema.
        </div>
        <a class="btn btn-light" href="consultasBitacora.aspx">Bitácora.</a>
        <br>
        <a class="btn btn-light" href="consultasTransacciones.aspx">Transacciones.</a>
        <br>
        <a class="btn btn-light" href="consultasDescargas.aspx">Descargas.</a>
        <br>
        <a class="btn btn-light" href="consultasErrores.aspx">Errores.</a>
        `;
    card_body.innerHTML = contenido; // Asigna el contenido al ID card_body.
}
