
-- Tabla: Descargas / Insertar 

GO
CREATE PROCEDURE sp_descargas_crear
@ID nvarchar(450),
@IDDescarga nvarchar(450),
@nombreDescarga nvarchar(450),
@cantidadDescarga nvarchar(450)
AS
BEGIN
INSERT INTO Descargas(
ID,
IDDescarga,
nombreDescarga,
cantidadDescarga
)
VALUES(
@ID,
@IDDescarga,
@nombreDescarga,
@cantidadDescarga
);
END

-- Tabla: Descargas / Actualizar

GO
CREATE PROCEDURE sp_descargas_actualizar
@ID nvarchar(450),
@IDDescarga nvarchar(450),
@nombreDescarga nvarchar(450),
@cantidadDescarga nvarchar(450)
AS
BEGIN
UPDATE Descargas
SET
ID = @ID,
IDDescarga = @IDDescarga,
nombreDescarga = @nombreDescarga,
cantidadDescarga = @cantidadDescarga
WHERE
ID = @ID
END

-- Tabla: Descargas / Eliminar

GO
CREATE PROCEDURE sp_descargas_eliminar
@ID nvarchar(450)
AS
BEGIN
DELETE Descargas WHERE ID = @ID
END

-- Tabla: Descargas / Leer

GO
CREATE PROCEDURE sp_descargas_leer
AS
BEGIN
SELECT * FROM Descargas
END