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
@IDadmin nvarchar(max),
@fechaYHora nvarchar(max),
@codigoDelRegistro nvarchar(max),
@tipo nvarchar(max),
@descripcion nvarchar(max),
@registroEnDetalle nvarchar(max)
AS
BEGIN
INSERT INTO Bitacora(
ID,
IDadmin,
fechaYHora,
codigoDelRegistro,
tipo,
descripcion,
registroEnDetalle
)
VALUES(
@ID,
@IDadmin,
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
@IDadmin nvarchar(max),
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
IDadmin = @IDadmin,
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
@IDError,
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