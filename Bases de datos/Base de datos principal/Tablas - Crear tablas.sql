-- Ejecutar comando USE primero antes de crear las tablas.
--USE SERVICIOSWEB_MAIN;

CREATE TABLE USUARIO(
ID NVARCHAR(MAX),
nombre NVARCHAR(MAX),
primerApellido NVARCHAR(MAX),
segundoApellido NVARCHAR(MAX),
correoElectronico NVARCHAR(MAX),
nombreUsuario NVARCHAR(MAX),
contrasenia NVARCHAR(MAX)
);

CREATE TABLE ADMIN(
ID NVARCHAR(MAX),
nombreUsuario NVARCHAR(MAX),
contrasenia NVARCHAR(MAX),
correoElectronico NVARCHAR(MAX),
preguntaSeguridad NVARCHAR(MAX),
respuestaSeguridad NVARCHAR(MAX),
adminMaestro NVARCHAR(MAX),
adminSeguridad NVARCHAR(MAX),
adminMantenimiento NVARCHAR(MAX),
adminConsultas NVARCHAR(MAX),
);

CREATE TABLE CONSECUTIVO(
ID NVARCHAR(MAX),
tipoConsecutivo NVARCHAR(MAX),
descripcion NVARCHAR(MAX),
prefijo NVARCHAR(MAX),
rangoInicial NVARCHAR(MAX),
rangoFinal NVARCHAR(MAX)
);

CREATE TABLE GENEROS_PELICULAS(
	ID nvarchar(max),
	genero nvarchar(max)
);

CREATE TABLE GENEROS_MUSICA(
	IDgeneroMus nvarchar(max),
	genero varchar(100)
);

CREATE TABLE CATEGORIAS_LIBROS(
	IDcategoriaLib nvarchar(max),
	categoria nvarchar(max)
);

CREATE TABLE PELICULA(
	ID nvarchar(max),
	nombre nvarchar(max),
	genero nvarchar(max),
	anio nvarchar(max),
	idioma nvarchar(max),
	actores nvarchar(max),
	nombreArchivoDescarga nvarchar(max),
	nombreArchivoPrevisualizacion nvarchar(max),
	monto nvarchar(max)
);

CREATE TABLE MUSICA(
	ID nvarchar(max),
	nombre nvarchar(max),
	genero nvarchar(max),
	tipoInterpretacion nvarchar(max),
	pais nvarchar(max),
	anio nvarchar(max),
	idioma nvarchar(max),
	diquera nvarchar(max),
	nombreDisco nvarchar(max),
	nombreArchivoDescarga nvarchar(max),
	nombreArchivoPrevisualizacion nvarchar(max),
	monto nvarchar(max)
);


CREATE TABLE LIBRO(
	ID nvarchar(max),
	nombre nvarchar(max),
	categoria nvarchar(max),
	autor nvarchar(max),
	idioma nvarchar(max),
	editorial nvarchar(max),
	anioPublicacion nvarchar(max),
	nombreArchivoDescarga nvarchar(max),
	nombreArchivoPrevisualizacion nvarchar(max),
	monto nvarchar(max)
);

CREATE TABLE TRANSACCION(
	ID nvarchar(max),
	IDtarjeta nvarchar(max),
	IDusuario nvarchar(max),
	IDcompra nvarchar(max),
	monto nvarchar(max),
	fechaCompra nvarchar(max)
);

CREATE TABLE BITACORA(
	ID nvarchar(max),
	IDadmin nvarchar(max),
	fechaYHora nvarchar(max),
	codigoDelRegistro nvarchar(max),
	tipo nvarchar(max),
	descripcion nvarchar(max),
	registroEnDetalle nvarchar(max)
);

CREATE TABLE PARAMETROS(
	ID nvarchar(max),
	rutaAlmacenamientoPrevisualizacionLibros nvarchar(max),
	rutaAlmacenamientoLibros nvarchar(max),
	rutaAlmacenamientoPrevisualizacionPeliculas nvarchar(max),
	rutaAlmacenamientoPeliculas nvarchar(max),
	rutaAlmacenamientoPrevisualizacionMusica nvarchar(max),
	rutaAlmacenamientoMusica nvarchar(max)
);

CREATE TABLE ERROR(
	ID nvarchar(max),
	fechaYHora nvarchar(max),
	IDusuario nvarchar(max),
	mensajeDeError nvarchar(max)
);