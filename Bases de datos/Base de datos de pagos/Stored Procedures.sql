
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
numeroTarjeta = @numeroTarjeta
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