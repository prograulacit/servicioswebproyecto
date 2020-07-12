
-- Tabla: Usuario / Insertar 

GO
CREATE PROCEDURE sp_usuario_crear
@ID nvarchar(450),
@IDusuario nvarchar(450),
@nombre nvarchar(450),
@primerApellido nvarchar(450),
@SegundoApellido nvarchar(450),
@correoElectronico nvarchar(450),
@nombreUsuario nvarchar(450),
@contrasenia nvarchar(450),
@preguntaSeguridad nvarchar(450),
@respuestaSeguridad nvarchar(450),
@adminStatus BIT,
@adminMaestro BIT,
@adminSeguridad BIT,
@adminMantenimiento BIT,
@adminConsultas BIT
AS
BEGIN
INSERT INTO Usuario(
ID,
IDusuario,
nombre,
primerApellido,
SegundoApellido,
correoElectronico,
nombreUsuario,
contrasenia,
preguntaSeguridad,
respuestaSeguridad,
adminStatus,
adminMaestro,
adminSeguridad,
adminMantenimiento,
adminConsultas
)
VALUES(
@ID,
@IDusuario,
@nombre,
@primerApellido,
@SegundoApellido,
@correoElectronico,
@nombreUsuario,
@contrasenia,
@preguntaSeguridad,
@respuestaSeguridad,
@adminStatus,
@adminMaestro,
@adminSeguridad,
@adminMantenimiento,
@adminConsultas
);
END

-- Tabla: Usuario / Actualizar

GO
CREATE PROCEDURE sp_usuario_actualizar
@ID nvarchar(450),
@IDusuario nvarchar(450),
@nombre nvarchar(450),
@primerApellido nvarchar(450),
@SegundoApellido nvarchar(450),
@correoElectronico nvarchar(450),
@nombreUsuario nvarchar(450),
@contrasenia nvarchar(450),
@preguntaSeguridad nvarchar(450),
@respuestaSeguridad nvarchar(450),
@adminStatus BIT,
@adminMaestro BIT,
@adminSeguridad BIT,
@adminMantenimiento BIT,
@adminConsultas BIT
AS
BEGIN
UPDATE Usuario
SET
ID = @ID,
IDusuario = @IDusuario,
nombre = @nombre,
primerApellido = @primerApellido,
SegundoApellido = @SegundoApellido,
correoElectronico = @correoElectronico,
nombreUsuario = @nombreUsuario,
contrasenia = @contrasenia,
preguntaSeguridad = @preguntaSeguridad,
respuestaSeguridad = @respuestaSeguridad,
adminStatus = @adminStatus,
adminMaestro = @adminMaestro,
adminSeguridad = @adminSeguridad,
adminMantenimiento = @adminMantenimiento,
adminConsultas = @adminConsultas
WHERE
ID = @ID
END

-- Tabla: Usuario / Eliminar

GO
CREATE PROCEDURE sp_usuario_eliminar
@ID nvarchar(450)
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