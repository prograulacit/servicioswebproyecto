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