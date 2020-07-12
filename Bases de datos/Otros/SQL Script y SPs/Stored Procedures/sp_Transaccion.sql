
-- Tabla: Transaccion / Insertar 

GO
CREATE PROCEDURE sp_transaccion_crear
@IDcompra nvarchar(450),
@IDusuario nvarchar(450),
@monto nvarchar(450),
@fechaCompra nvarchar(450),
@IDtarjeta nvarchar(450)
AS
BEGIN
INSERT INTO Transaccion(
IDcompra,
IDusuario,
monto,
fechaCompra,
IDtarjeta
)
VALUES(
@IDcompra,
@IDusuario,
@monto,
@fechaCompra,
@IDtarjeta
);
END

-- Tabla: Transaccion / Actualizar

GO
CREATE PROCEDURE sp_transaccion_actualizar
@IDcompra nvarchar(450),
@IDusuario nvarchar(450),
@monto nvarchar(450),
@fechaCompra nvarchar(450),
@IDtarjeta nvarchar(450)
AS
BEGIN
UPDATE Transaccion
SET
IDcompra = @IDcompra,
IDusuario = @IDusuario,
monto = @monto,
fechaCompra = @fechaCompra,
IDtarjeta = @IDtarjeta
WHERE
IDcompra = @IDcompra
END

-- Tabla: Transaccion / Eliminar

GO
CREATE PROCEDURE sp_transaccion_eliminar
@IDcompra nvarchar(450)
AS
BEGIN
DELETE Transaccion WHERE IDcompra = @IDcompra
END

-- Tabla: Transaccion / Leer

GO
CREATE PROCEDURE sp_transaccion_leer
AS
BEGIN
SELECT * FROM Transaccion
END