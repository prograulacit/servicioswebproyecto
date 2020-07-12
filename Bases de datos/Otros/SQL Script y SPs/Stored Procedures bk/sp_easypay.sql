
-- Tabla: Easypay / Insertar 

GO
CREATE PROCEDURE sp_easypay_crear
@numerocuenta nvarchar(450),
@IDusuario nvarchar(450),
@codigoSeguridad nvarchar(450),
@contrasenia nvarchar(450)
AS
BEGIN
INSERT INTO Easypay(
numerocuenta,
IDusuario,
codigoSeguridad,
contrasenia
)
VALUES(
@numerocuenta,
@IDusuario,
@codigoSeguridad,
@contrasenia
);
END

-- Tabla: Easypay / Actualizar

GO
CREATE PROCEDURE sp_easypay_actualizar
@numerocuenta nvarchar(450),
@IDusuario nvarchar(450),
@codigoSeguridad nvarchar(450),
@contrasenia nvarchar(450)
AS
BEGIN
UPDATE Easypay
SET
numerocuenta = @numerocuenta,
IDusuario = @IDusuario,
codigoSeguridad = @codigoSeguridad,
contrasenia = @contrasenia
WHERE
numerocuenta = @numerocuenta
END

-- Tabla: Easypay / Eliminar

GO
CREATE PROCEDURE sp_easypay_eliminar
@numerocuenta nvarchar(450)
AS
BEGIN
DELETE Easypay WHERE numerocuenta = @numerocuenta
END

-- Tabla: Easypay / Leer

GO
CREATE PROCEDURE sp_easypay_leer
AS
BEGIN
SELECT * FROM Easypay
END