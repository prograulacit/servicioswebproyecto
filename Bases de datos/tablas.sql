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