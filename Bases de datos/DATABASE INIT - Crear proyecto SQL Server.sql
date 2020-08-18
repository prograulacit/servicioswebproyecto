-- Creación de la base de datos principal
CREATE DATABASE SERVICIOSWEB_MAIN;
GO
USE SERVICIOSWEB_MAIN;
GO

----------------------------
-- Creación de tablas para base de datos principal.
----------------------------

CREATE TABLE DESCARGAS(
	ID nvarchar(max),
	IDconsecutivo nvarchar(max),
	nombre nvarchar(max),
	cantidad nvarchar(max),
	fechaYHora nvarchar(max),
	tipo nvarchar(max),
);

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
	ID nvarchar(max),
	genero varchar(max)
);

CREATE TABLE CATEGORIAS_LIBROS(
	ID nvarchar(max),
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
	disquera nvarchar(max),
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
	fechaCompra nvarchar(max),
	monto nvarchar(max),
	usuarioID nvarchar(max),
	consecutivoProductoID nvarchar(max),
	tarjetaID nvarchar(max),
	easyPayID nvarchar(max)
);

CREATE TABLE BITACORA(
	ID nvarchar(max),
	nombreUsuarioAdmin nvarchar(max),
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

-- Creación de Stored Procedures

--SP para crear nuevos admins.
GO
CREATE PROCEDURE sp_admin_crear
@ID nvarchar(max),
@nombreUsuario nvarchar(max),
@contrasenia nvarchar(max),
@correoElectronico nvarchar(max),
@preguntaSeguridad nvarchar(max),
@respuestaSeguridad nvarchar(max),
@adminMaestro nvarchar(max),
@adminSeguridad nvarchar(max),
@adminMantenimiento nvarchar(max),
@adminConsultas nvarchar(max)
AS
BEGIN
INSERT INTO ADMIN(
ID,
nombreUsuario,
contrasenia,
correoElectronico,
preguntaSeguridad,
respuestaSeguridad,
adminMaestro,
adminSeguridad,
adminMantenimiento,
adminConsultas
)
VALUES(
@ID,
@nombreUsuario,
@contrasenia,
@correoElectronico,
@preguntaSeguridad,
@respuestaSeguridad,
@adminMaestro,
@adminSeguridad,
@adminMantenimiento,
@adminConsultas
);
END

--SP para alctualizar informacion de admins.
GO
CREATE PROCEDURE sp_admin_actualizar
@ID nvarchar(max),
@nombreUsuario nvarchar(max),
@contrasenia nvarchar(max),
@correoElectronico nvarchar(max),
@preguntaSeguridad nvarchar(max),
@respuestaSeguridad nvarchar(max),
@adminMaestro nvarchar(max),
@adminSeguridad nvarchar(max),
@adminMantenimiento nvarchar(max),
@adminConsultas nvarchar(max)
AS
BEGIN
UPDATE ADMIN 
SET
ID = @ID,
nombreUsuario = @nombreUsuario,
contrasenia = @contrasenia,
correoElectronico = @correoElectronico,
preguntaSeguridad = @preguntaSeguridad,
respuestaSeguridad = @respuestaSeguridad,
adminMaestro = @adminMaestro,
adminSeguridad = @adminSeguridad,
adminMantenimiento = @adminMantenimiento,
adminConsultas = @adminConsultas
WHERE
ID = @ID;
END

--SP para eliminar admins
GO
CREATE PROCEDURE sp_admin_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE ADMIN WHERE ID = @ID
END

--SP para traer registros de admins.
GO
CREATE PROCEDURE sp_admin_traer
AS
BEGIN
SELECT * FROM ADMIN
END

--SP crear consecutivos
GO
CREATE PROCEDURE sp_consecutivo_crear
@ID nvarchar(max),
@tipoConsecutivo nvarchar(max),
@descripcion nvarchar(max),
@prefijo nvarchar(max),
@rangoInicial nvarchar(max),
@rangoFinal nvarchar(max)
AS
BEGIN
INSERT INTO CONSECUTIVO(
ID,
tipoConsecutivo,
descripcion,
prefijo,
rangoInicial,
rangoFinal
)
VALUES(
@ID,
@tipoConsecutivo,
@descripcion,
@prefijo,
@rangoInicial,
@rangoFinal
);
END

--SP leer consecutivos
GO
CREATE PROCEDURE sp_consecutivo_traer
AS
BEGIN
SELECT * FROM CONSECUTIVO
END

GO
CREATE PROCEDURE sp_consecutivo_actualizar
@ID nvarchar(max),
@tipoConsecutivo nvarchar(max),
@descripcion nvarchar(max),
@prefijo nvarchar(max),
@rangoInicial nvarchar(max),
@rangoFinal nvarchar(max)
AS
BEGIN
UPDATE Consecutivo
SET
ID = @ID,
tipoConsecutivo = @tipoConsecutivo,
descripcion = @descripcion,
prefijo = @prefijo,
rangoInicial = @rangoInicial,
rangoFinal = @rangoFinal
WHERE
ID = @ID
END

-- Tabla: Consecutivo / Eliminar

GO
CREATE PROCEDURE sp_consecutivo_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE Consecutivo WHERE ID = @ID
END


-- Tabla: Bitacora / Insertar 

GO
CREATE PROCEDURE sp_bitacora_crear
@ID nvarchar(max),
@nombreUsuarioAdmin nvarchar(max),
@fechaYHora nvarchar(max),
@codigoDelRegistro nvarchar(max),
@tipo nvarchar(max),
@descripcion nvarchar(max),
@registroEnDetalle nvarchar(max)
AS
BEGIN
INSERT INTO Bitacora(
ID,
nombreUsuarioAdmin,
fechaYHora,
codigoDelRegistro,
tipo,
descripcion,
registroEnDetalle
)
VALUES(
@ID,
@nombreUsuarioAdmin,
@fechaYHora,
@codigoDelRegistro,
@tipo,
@descripcion,
@registroEnDetalle
);
END

-- Tabla: Bitacora / Actualizar

GO
CREATE PROCEDURE sp_bitacora_actualizar
@ID nvarchar(max),
@nombreUsuarioAdmin nvarchar(max),
@fechaYHora nvarchar(max),
@codigoDelRegistro nvarchar(max),
@tipo nvarchar(max),
@descripcion nvarchar(max),
@registroEnDetalle nvarchar(max)
AS
BEGIN
UPDATE Bitacora
SET
ID = @ID,
nombreUsuarioAdmin = @nombreUsuarioAdmin,
fechaYHora = @fechaYHora,
codigoDelRegistro = @codigoDelRegistro,
tipo = @tipo,
descripcion = @descripcion,
registroEnDetalle = @registroEnDetalle
WHERE
ID = @ID
END

-- Tabla: Bitacora / Eliminar

GO
CREATE PROCEDURE sp_bitacora_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE Bitacora WHERE ID = @ID
END

-- Tabla: Bitacora / Leer

GO
CREATE PROCEDURE sp_bitacora_traer
AS
BEGIN
SELECT * FROM Bitacora
END


-- Tabla: Error / Insertar 

GO
CREATE PROCEDURE sp_error_crear
@ID nvarchar(max),
@fechaYHora nvarchar(max),
@IDusuario nvarchar(max),
@mensajeDeError nvarchar(max)
AS
BEGIN
INSERT INTO Error(
ID,
fechaYHora,
IDusuario,
mensajeDeError
)
VALUES(
@ID,
@fechaYHora,
@IDusuario,
@mensajeDeError
);
END

-- Tabla: Error / Actualizar

GO
CREATE PROCEDURE sp_error_actualizar
@ID nvarchar(max),
@fechaYHora nvarchar(max),
@IDusuario nvarchar(max),
@mensajeDeError nvarchar(max)
AS
BEGIN
UPDATE Error
SET
ID = @ID,
fechaYHora = @fechaYHora,
IDusuario = @IDusuario,
mensajeDeError = @mensajeDeError
WHERE
ID = @ID
END

-- Tabla: Error / Eliminar

GO
CREATE PROCEDURE sp_error_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE Error WHERE ID = @ID
END

-- Tabla: Error / Leer

GO
CREATE PROCEDURE sp_error_leer
AS
BEGIN
SELECT * FROM Error
END


-- Tabla: Parametros / Insertar 

GO
CREATE PROCEDURE sp_parametros_crear
@ID nvarchar(max),
@rutaAlmacenamientoPrevisualizacionLibros nvarchar(max),
@rutaAlmacenamientoLibros nvarchar(max),
@rutaAlmacenamientoPrevisualizacionPeliculas nvarchar(max),
@rutaAlmacenamientoPeliculas nvarchar(max),
@rutaAlmacenamientoPrevisualizacionMusica nvarchar(max),
@rutaAlmacenamientoMusica nvarchar(max)
AS
BEGIN
INSERT INTO Parametros(
ID,
rutaAlmacenamientoPrevisualizacionLibros,
rutaAlmacenamientoLibros,
rutaAlmacenamientoPrevisualizacionPeliculas,
rutaAlmacenamientoPeliculas,
rutaAlmacenamientoPrevisualizacionMusica,
rutaAlmacenamientoMusica
)
VALUES(
@ID,
@rutaAlmacenamientoPrevisualizacionLibros,
@rutaAlmacenamientoLibros,
@rutaAlmacenamientoPrevisualizacionPeliculas,
@rutaAlmacenamientoPeliculas,
@rutaAlmacenamientoPrevisualizacionMusica,
@rutaAlmacenamientoMusica
);
END

-- Tabla: Parametros / Actualizar

GO
CREATE PROCEDURE sp_parametros_actualizar
@ID nvarchar(max),
@rutaAlmacenamientoPrevisualizacionLibros nvarchar(max),
@rutaAlmacenamientoLibros nvarchar(max),
@rutaAlmacenamientoPrevisualizacionPeliculas nvarchar(max),
@rutaAlmacenamientoPeliculas nvarchar(max),
@rutaAlmacenamientoPrevisualizacionMusica nvarchar(max),
@rutaAlmacenamientoMusica nvarchar(max)
AS
BEGIN
UPDATE Parametros
SET
ID = @ID,
rutaAlmacenamientoPrevisualizacionLibros = @rutaAlmacenamientoPrevisualizacionLibros,
rutaAlmacenamientoLibros = @rutaAlmacenamientoLibros,
rutaAlmacenamientoPrevisualizacionPeliculas = @rutaAlmacenamientoPrevisualizacionPeliculas,
rutaAlmacenamientoPeliculas = @rutaAlmacenamientoPeliculas,
rutaAlmacenamientoPrevisualizacionMusica = @rutaAlmacenamientoPrevisualizacionMusica,
rutaAlmacenamientoMusica = @rutaAlmacenamientoMusica
WHERE
ID = @ID
END

-- Tabla: Parametros / Eliminar

GO
CREATE PROCEDURE sp_parametros_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE Parametros WHERE ID = @ID
END

-- Tabla: Parametros / Leer

GO
CREATE PROCEDURE sp_parametros_leer
AS
BEGIN
SELECT * FROM Parametros
END


-- Tabla: Usuario / Insertar 

GO
CREATE PROCEDURE sp_usuario_crear
@ID nvarchar(max),
@nombre nvarchar(max),
@primerApellido nvarchar(max),
@SegundoApellido nvarchar(max),
@correoElectronico nvarchar(max),
@nombreUsuario nvarchar(max),
@contrasenia nvarchar(max)
AS
BEGIN
INSERT INTO Usuario(
ID,
nombre,
primerApellido,
SegundoApellido,
correoElectronico,
nombreUsuario,
contrasenia
)
VALUES(
@ID,
@nombre,
@primerApellido,
@SegundoApellido,
@correoElectronico,
@nombreUsuario,
@contrasenia
);
END

-- Tabla: Usuario / Actualizar

GO
CREATE PROCEDURE sp_usuario_actualizar
@ID nvarchar(max),
@nombre nvarchar(max),
@primerApellido nvarchar(max),
@SegundoApellido nvarchar(max),
@correoElectronico nvarchar(max),
@nombreUsuario nvarchar(max),
@contrasenia nvarchar(max)
AS
BEGIN
UPDATE Usuario
SET
ID = @ID,
nombre = @nombre,
primerApellido = @primerApellido,
SegundoApellido = @SegundoApellido,
correoElectronico = @correoElectronico,
nombreUsuario = @nombreUsuario,
contrasenia = @contrasenia
WHERE
ID = @ID
END

-- Tabla: Usuario / Eliminar

GO
CREATE PROCEDURE sp_usuario_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE Usuario WHERE ID = @ID
END

-- Tabla: Usuario / Leer

GO
CREATE PROCEDURE sp_usuario_leer
AS
BEGIN
SELECT * FROM Usuario
END


-- Tabla: Pelicula / Insertar 

GO
CREATE PROCEDURE sp_pelicula_crear
@ID nvarchar(max),
@nombre nvarchar(max),
@genero nvarchar(max),
@anio nvarchar(max),
@idioma nvarchar(max),
@actores nvarchar(max),
@nombreArchivoDescarga nvarchar(max),
@nombreArchivoPrevisualizacion nvarchar(max),
@monto nvarchar(max)
AS
BEGIN
INSERT INTO Pelicula(
ID,
nombre,
genero,
anio,
idioma,
actores,
nombreArchivoDescarga,
nombreArchivoPrevisualizacion,
monto
)
VALUES(
@ID,
@nombre,
@genero,
@anio,
@idioma,
@actores,
@nombreArchivoDescarga,
@nombreArchivoPrevisualizacion,
@monto
);
END

-- Tabla: Pelicula / Actualizar

GO
CREATE PROCEDURE sp_pelicula_actualizar
@ID nvarchar(max),
@nombre nvarchar(max),
@genero nvarchar(max),
@anio nvarchar(max),
@idioma nvarchar(max),
@actores nvarchar(max),
@nombreArchivoDescarga nvarchar(max),
@nombreArchivoPrevisualizacion nvarchar(max),
@monto nvarchar(max)
AS
BEGIN
UPDATE Pelicula
SET
ID = @ID,
nombre = @nombre,
genero = @genero,
anio = @anio,
idioma = @idioma,
actores = @actores,
nombreArchivoDescarga = @nombreArchivoDescarga,
nombreArchivoPrevisualizacion = @nombreArchivoPrevisualizacion,
monto = @monto
WHERE
ID = @ID
END

-- Tabla: Pelicula / Eliminar

GO
CREATE PROCEDURE sp_pelicula_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE Pelicula WHERE ID = @ID
END

-- Tabla: Pelicula / Leer

GO
CREATE PROCEDURE sp_pelicula_leer
AS
BEGIN
SELECT * FROM Pelicula
END


-- Tabla: Generos_Libros / Insertar 

GO
CREATE PROCEDURE sp_categorias_libros_crear
@ID nvarchar(max),
@categoria nvarchar(max)
AS
BEGIN
INSERT INTO CATEGORIAS_LIBROS(
ID,
categoria
)
VALUES(
@ID,
@categoria
);
END

-- Tabla: Generos_Libros / Actualizar

GO
CREATE PROCEDURE sp_categorias_libros_actualizar
@ID nvarchar(max),
@categoria nvarchar(max)
AS
BEGIN
UPDATE CATEGORIAS_LIBROS
SET
ID = @ID,
categoria = @categoria
WHERE
ID = @ID
END

-- Tabla: Generos_Libros / Eliminar

GO
CREATE PROCEDURE sp_categorias_libros_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE CATEGORIAS_LIBROS WHERE ID = @ID
END

-- Tabla: Generos_Libros / Leer

GO
CREATE PROCEDURE sp_categorias_libros_leer
AS
BEGIN
SELECT * FROM CATEGORIAS_LIBROS
END

-- Tabla: Generos_Musica / Insertar 

GO
CREATE PROCEDURE sp_generos_musica_crear
@ID nvarchar(max),
@genero nvarchar(max)
AS
BEGIN
INSERT INTO GENEROS_MUSICA(
ID,
genero
)
VALUES(
@ID,
@genero
);
END

-- Tabla: Generos_Musica / Actualizar

GO
CREATE PROCEDURE sp_generos_musica_actualizar
@ID nvarchar(max),
@genero nvarchar(max)
AS
BEGIN
UPDATE GENEROS_MUSICA
SET
ID = @ID,
genero = @genero
WHERE
ID = @ID
END

-- Tabla: Generos_Musica / Eliminar

GO
CREATE PROCEDURE sp_generos_musica_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE GENEROS_MUSICA WHERE ID = @ID
END

-- Tabla: Generos_Musica / Leer

GO
CREATE PROCEDURE sp_generos_musica_leer
AS
BEGIN
SELECT * FROM GENEROS_MUSICA
END


-- Tabla: Generos_Pelicula / Insertar 

GO
CREATE PROCEDURE sp_generos_peliculas_crear
@ID nvarchar(max),
@genero nvarchar(max)
AS
BEGIN
INSERT INTO GENEROS_PELICULAS(
ID,
genero
)
VALUES(
@ID,
@genero
);
END


-- Tabla: Generos_Pelicula / Actualizar

GO
CREATE PROCEDURE sp_generos_peliculas_actualizar
@ID nvarchar(max),
@genero nvarchar(max)
AS
BEGIN
UPDATE GENEROS_PELICULAS
SET
ID = @ID,
genero = @genero
WHERE
ID = @ID
END

-- Tabla: Generos_Pelicula / Eliminar

GO
CREATE PROCEDURE sp_generos_peliculas_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE GENEROS_PELICULAS WHERE ID = @ID
END

-- Tabla: Generos_Pelicula / Leer

GO
CREATE PROCEDURE sp_generos_pelicula_leer
AS
BEGIN
SELECT * FROM GENEROS_PELICULAS
END


-- Tabla: Descargas / Insertar 

GO
CREATE PROCEDURE sp_descargas_crear
@ID nvarchar(max),
@IDconsecutivo nvarchar(max),
@nombre nvarchar(max),
@cantidad nvarchar(max),
@fechaYHora nvarchar(max),
@tipo nvarchar(max)
AS
BEGIN
INSERT INTO DESCARGAS(
ID,
IDconsecutivo,
nombre,
cantidad,
fechaYHora,
tipo
)
VALUES(
@ID,
@IDconsecutivo,
@nombre,
@cantidad,
@fechaYHora,
@tipo
);
END

-- Tabla: Descargas / Actualizar

GO
CREATE PROCEDURE sp_descargas_actualizar
@ID nvarchar(max),
@IDconsecutivo nvarchar(max),
@nombre nvarchar(max),
@cantidad nvarchar(max),
@fechaYHora nvarchar(max),
@tipo nvarchar(max)
AS
BEGIN
UPDATE DESCARGAS
SET
ID = @ID,
IDconsecutivo = @IDconsecutivo,
nombre = @nombre,
cantidad = @cantidad,
fechaYHora = @fechaYHora,
tipo = @tipo
WHERE
ID = @ID
END

-- Tabla: Descargas / Eliminar

GO
CREATE PROCEDURE sp_descargas_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE DESCARGAS WHERE ID = @ID
END

-- Tabla: Descargas / Leer

GO
CREATE PROCEDURE sp_descargas_leer
AS
BEGIN
SELECT * FROM DESCARGAS
END


-- Tabla: Transaccion / Insertar 

GO
CREATE PROCEDURE sp_transaccion_crear
@ID nvarchar(max),
@fechaCompra nvarchar(max),
@monto nvarchar(max),
@usuarioID nvarchar(max),
@consecutivoProductoID nvarchar(max),
@tarjetaID nvarchar(max),
@easyPayID nvarchar(max)
AS
BEGIN
INSERT INTO TRANSACCION(
ID,
fechaCompra,
monto,
usuarioID,
consecutivoProductoID,
tarjetaID,
easyPayID
)
VALUES(
@ID,
@fechaCompra,
@monto,
@usuarioID,
@consecutivoProductoID,
@tarjetaID,
@easyPayID
);
END

-- Tabla: Transaccion / Actualizar

GO
CREATE PROCEDURE sp_transaccion_actualizar
@ID nvarchar(max),
@fechaCompra nvarchar(max),
@monto nvarchar(max),
@usuarioID nvarchar(max),
@consecutivoProductoID nvarchar(max),
@tarjetaID nvarchar(max),
@easyPayID nvarchar(max)
AS
BEGIN
UPDATE TRANSACCION
SET
ID = @ID,
fechaCompra = @fechaCompra,
monto = @monto,
usuarioID = @usuarioID,
consecutivoProductoID = @consecutivoProductoID,
tarjetaID = @tarjetaID,
easyPayID = @easyPayID
WHERE
ID = @ID
END

-- Tabla: Transaccion / Eliminar

GO
CREATE PROCEDURE sp_transaccion_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE TRANSACCION WHERE ID = @ID
END

-- Tabla: Transaccion / Leer

GO
CREATE PROCEDURE sp_transaccion_leer
AS
BEGIN
SELECT * FROM TRANSACCION
END


-- Tabla: Libro / Insertar 

GO
CREATE PROCEDURE sp_libro_crear
@ID nvarchar(max),
@nombre nvarchar(max),
@categoria nvarchar(max),
@autor nvarchar(max),
@idioma nvarchar(max),
@editorial nvarchar(max),
@anioPublicacion nvarchar(max),
@nombreArchivoDescarga nvarchar(max),
@nombreArchivoPrevisualizacion nvarchar(max),
@monto nvarchar(max)
AS
BEGIN
INSERT INTO Libro(
ID,
nombre,
categoria,
autor,
idioma,
editorial,
anioPublicacion,
nombreArchivoDescarga ,
nombreArchivoPrevisualizacion,
monto
)
VALUES(
@ID,
@nombre,
@categoria,
@autor,
@idioma,
@editorial,
@anioPublicacion,
@nombreArchivoDescarga ,
@nombreArchivoPrevisualizacion,
@monto
);
END

-- Tabla: Libro / Actualizar

GO
CREATE PROCEDURE sp_libro_actualizar
@ID nvarchar(max),
@nombre nvarchar(max),
@categoria nvarchar(max),
@autor nvarchar(max),
@idioma nvarchar(max),
@editorial nvarchar(max),
@anioPublicacion nvarchar(max),
@nombreArchivoDescarga nvarchar(max),
@nombreArchivoPrevisualizacion nvarchar(max),
@monto nvarchar(max)
AS
BEGIN
UPDATE Libro
SET
ID = @ID,
nombre = @nombre,
categoria = @categoria,
autor = @autor,
idioma = @idioma,
editorial = @editorial,
anioPublicacion = @anioPublicacion,
nombreArchivoDescarga = @nombreArchivoDescarga ,
nombreArchivoPrevisualizacion = @nombreArchivoPrevisualizacion,
monto = @monto
WHERE
ID = @ID
END

-- Tabla: Libro / Eliminar

GO
CREATE PROCEDURE sp_libro_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE Libro WHERE ID = @ID
END

-- Tabla: Libro / Leer

GO
CREATE PROCEDURE sp_libro_leer
AS
BEGIN
SELECT * FROM Libro
END


-- Tabla: Musica / Insertar 

GO
CREATE PROCEDURE sp_musica_crear
@ID nvarchar(max),
@nombre nvarchar(max),
@genero nvarchar(max),
@tipoInterpretacion nvarchar(max),
@idioma nvarchar(max),
@pais nvarchar(max),
@disquera nvarchar(max),
@nombreDisco nvarchar(max),
@anio nvarchar(max),
@nombreArchivoDescarga nvarchar(max),
@nombreArchivoPrevisualizacion nvarchar(max),
@monto nvarchar(max)
AS
BEGIN
INSERT INTO Musica(
ID,
nombre,
genero,
tipoInterpretacion,
idioma,
pais,
disquera,
nombreDisco,
anio,
nombreArchivoDescarga,
nombreArchivoPrevisualizacion,
monto
)
VALUES(
@ID,
@nombre,
@genero,
@tipoInterpretacion,
@idioma,
@pais,
@disquera,
@nombreDisco,
@anio,
@nombreArchivoDescarga,
@nombreArchivoPrevisualizacion,
@monto
);
END

-- Tabla: Musica / Actualizar

GO
CREATE PROCEDURE sp_musica_actualizar
@ID nvarchar(max),
@nombre nvarchar(max),
@genero nvarchar(max),
@tipoInterpretacion nvarchar(max),
@idioma nvarchar(max),
@pais nvarchar(max),
@disquera nvarchar(max),
@nombreDisco nvarchar(max),
@anio nvarchar(max),
@nombreArchivoDescarga nvarchar(max),
@nombreArchivoPrevisualizacion nvarchar(max),
@monto nvarchar(max)
AS
BEGIN
UPDATE Musica
SET
ID = @ID,
nombre = @nombre,
genero = @genero,
tipoInterpretacion = @tipoInterpretacion,
idioma = @idioma,
pais = @pais,
disquera = @disquera,
nombreDisco = @nombreDisco,
anio = @anio,
nombreArchivoDescarga = @nombreArchivoDescarga,
nombreArchivoPrevisualizacion = @nombreArchivoPrevisualizacion,
monto = @monto
WHERE
ID = @ID
END

-- Tabla: Musica / Eliminar

GO
CREATE PROCEDURE sp_musica_eliminar
@ID nvarchar(450)
AS
BEGIN
DELETE Musica WHERE ID = @ID
END

-- Tabla: Musica / Leer

GO
CREATE PROCEDURE sp_musica_leer
AS
BEGIN
SELECT * FROM Musica
END
GO

-- Contraints
-- Aun no definidos.

-- Creacion de base de datos de pagos.
CREATE DATABASE SERVICIOSWEB_PAGOS;
GO
USE SERVICIOSWEB_PAGOS;
GO

-- Creación de tablas.
CREATE TABLE TARJETA(
	ID nvarchar(max),
	IDusuario nvarchar(max),
	numeroTarjeta nvarchar(max),
	mesExpiracion nvarchar(max),
	anioExpiracion nvarchar(max),
	CVV nvarchar(max),
	monto nvarchar(max),
	tipo nvarchar(max)
);

CREATE TABLE EASYPAY(
	ID nvarchar(max),
	IDusuario nvarchar(max),
	numeroCuenta nvarchar(max),
	codigoSeguridad nvarchar(max),
	contrasenia nvarchar(max),
	monto nvarchar(max)
);
GO

-- Creación de Stored Procedures

-- Tabla: Easypay / Insertar 

GO
CREATE PROCEDURE sp_easypay_crear
@ID nvarchar(max),
@IDusuario nvarchar(max),
@numeroCuenta nvarchar(max),
@codigoSeguridad nvarchar(max),
@contrasenia nvarchar(max),
@monto nvarchar(max)
AS
BEGIN
INSERT INTO Easypay(
ID,
IDusuario,
numeroCuenta,
codigoSeguridad,
contrasenia,
monto
)
VALUES(
@ID,
@IDusuario,
@numeroCuenta,
@codigoSeguridad,
@contrasenia,
@monto
);
END

-- Tabla: Easypay / Actualizar

GO
CREATE PROCEDURE sp_easypay_actualizar
@ID nvarchar(max),
@IDusuario nvarchar(max),
@numeroCuenta nvarchar(max),
@codigoSeguridad nvarchar(max),
@contrasenia nvarchar(max),
@monto nvarchar(max)
AS
BEGIN
UPDATE Easypay
SET
ID = @ID,
IDusuario = @IDusuario,
numeroCuenta = @numeroCuenta,
codigoSeguridad = @codigoSeguridad,
contrasenia = @contrasenia,
monto = @monto
WHERE
ID = @ID
END

-- Tabla: Easypay / Eliminar

GO
CREATE PROCEDURE sp_easypay_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE Easypay WHERE ID = @ID
END

-- Tabla: Easypay / Leer

GO
CREATE PROCEDURE sp_easypay_leer
AS
BEGIN
SELECT * FROM Easypay
END


-- Tabla: Tarjeta / Insertar 

GO
CREATE PROCEDURE sp_tarjeta_crear
@ID nvarchar(max),
@IDusuario nvarchar(max),
@numeroTarjeta nvarchar(max),
@mesExpiracion nvarchar(max),
@anioExpiracion nvarchar(max),
@CVV nvarchar(max),
@monto nvarchar(max),
@tipo nvarchar(max)
AS
BEGIN
INSERT INTO Tarjeta(
ID,
IDusuario,
numeroTarjeta,
mesExpiracion,
anioExpiracion,
CVV,
monto,
tipo
)
VALUES(
@ID,
@IDusuario,
@numeroTarjeta,
@mesExpiracion,
@anioExpiracion,
@CVV,
@monto,
@tipo
);
END

-- Tabla: Tarjeta / Actualizar

GO
CREATE PROCEDURE sp_tarjeta_actualizar
@ID nvarchar(max),
@IDusuario nvarchar(max),
@numeroTarjeta nvarchar(max),
@mesExpiracion nvarchar(max),
@anioExpiracion nvarchar(max),
@CVV nvarchar(max),
@monto nvarchar(max),
@tipo nvarchar(max)
AS
BEGIN
UPDATE Tarjeta
SET
ID = @ID,
IDusuario = @IDusuario,
numeroTarjeta = @numeroTarjeta,
mesExpiracion = @mesExpiracion,
anioExpiracion = @anioExpiracion,
CVV = @CVV,
monto = @monto,
tipo = @tipo
WHERE
ID = @ID
END

-- Tabla: Tarjeta / Eliminar

GO
CREATE PROCEDURE sp_tarjeta_eliminar
@ID nvarchar(max)
AS
BEGIN
DELETE Tarjeta WHERE ID = @ID
END

-- Tabla: Tarjeta / Leer

GO
CREATE PROCEDURE sp_tarjeta_leer
AS
BEGIN
SELECT * FROM Tarjeta
END

GO
USE SERVICIOSWEB_MAIN;
GO
