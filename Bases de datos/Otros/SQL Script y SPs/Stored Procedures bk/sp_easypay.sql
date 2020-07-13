
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
@ID
@IDusuario,
@numerocuenta,
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