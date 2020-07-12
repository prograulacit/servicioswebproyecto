
-- Tabla: Bitacora / Insertar 

GO
CREATE PROCEDURE sp_bitacora_crear
@ID nvarchar(450),
@IDusuario nvarchar(450),
@fechaYHora nvarchar(450),
@codigoDelRegistro nvarchar(450),
@tipo nvarchar(450),
@descripcion nvarchar(450),
@registroEnDetalle nvarchar(450)
AS
BEGIN
INSERT INTO Bitacora(
ID,
IDusuario,
fechaYHora,
codigoDelRegistro,
tipo,
descripcion,
registroEnDetalle
)
VALUES(
@ID,
@IDusuario,
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
@ID nvarchar(450),
@IDusuario nvarchar(450),
@fechaYHora nvarchar(450),
@codigoDelRegistro nvarchar(450),
@tipo nvarchar(450),
@descripcion nvarchar(450),
@registroEnDetalle nvarchar(450)
AS
BEGIN
UPDATE Bitacora
SET
ID = @ID,
IDusuario = @IDusuario,
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
@ID nvarchar(450)
AS
BEGIN
DELETE Bitacora WHERE ID = @ID
END

-- Tabla: Bitacora / Leer

GO
CREATE PROCEDURE sp_bitacora_leer
AS
BEGIN
SELECT * FROM Bitacora
END