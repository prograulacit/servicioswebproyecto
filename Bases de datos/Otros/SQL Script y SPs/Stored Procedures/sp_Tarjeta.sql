
-- Tabla: Tarjeta / Insertar 

GO
CREATE PROCEDURE sp_tarjeta_crear
@numeroTarjeta nvarchar(450),
@IDusuario nvarchar(450),
@mesExpiracion nvarchar(450),
@anioExpiracion nvarchar(450),
@CVV nvarchar(450),
@tipo nvarchar(450)
AS
BEGIN
INSERT INTO Tarjeta(
numeroTarjeta,
IDusuario,
mesExpiracion,
anioExpiracion,
CVV,
tipo
)
VALUES(
@numeroTarjeta,
@IDusuario,
@mesExpiracion,
@anioExpiracion,
@CVV,
@tipo
);
END

-- Tabla: Tarjeta / Actualizar

GO
CREATE PROCEDURE sp_tarjeta_actualizar
@numeroTarjeta nvarchar(450),
@IDusuario nvarchar(450),
@mesExpiracion nvarchar(450),
@anioExpiracion nvarchar(450),
@CVV nvarchar(450),
@tipo nvarchar(450)
AS
BEGIN
UPDATE Tarjeta
SET
numeroTarjeta = @numeroTarjeta,
IDusuario = @IDusuario,
mesExpiracion = @mesExpiracion,
anioExpiracion = @anioExpiracion,
CVV = @CVV,
tipo = @tipo
WHERE
numeroTarjeta = @numeroTarjeta
END

-- Tabla: Tarjeta / Eliminar

GO
CREATE PROCEDURE sp_tarjeta_eliminar
@numeroTarjeta nvarchar(450)
AS
BEGIN
DELETE Tarjeta WHERE numeroTarjeta = @numeroTarjeta
END

-- Tabla: Tarjeta / Leer

GO
CREATE PROCEDURE sp_tarjeta_leer
AS
BEGIN
SELECT * FROM Tarjeta
END