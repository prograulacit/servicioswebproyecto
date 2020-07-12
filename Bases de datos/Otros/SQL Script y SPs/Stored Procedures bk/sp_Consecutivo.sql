
-- Tabla: Consecutivo / Insertar 

GO
CREATE PROCEDURE sp_consecutivo_crear
@ID nvarchar(450),
@tipoConsecutivo nvarchar(450),
@descripcion nvarchar(450),
@prefijo nvarchar(450),
@rangoInicial nvarchar(450),
@rangoFinal nvarchar(450)
AS
BEGIN
INSERT INTO Consecutivo(
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

-- Tabla: Consecutivo / Actualizar

GO
CREATE PROCEDURE sp_consecutivo_actualizar
@ID nvarchar(450),
@tipoConsecutivo nvarchar(450),
@descripcion nvarchar(450),
@prefijo nvarchar(450),
@rangoInicial nvarchar(450),
@rangoFinal nvarchar(450)
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
@ID nvarchar(450)
AS
BEGIN
DELETE Consecutivo WHERE ID = @ID
END

-- Tabla: Consecutivo / Leer

GO
CREATE PROCEDURE sp_consecutivo_leer
AS
BEGIN
SELECT * FROM Consecutivo
END