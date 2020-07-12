
-- Tabla: Error / Insertar 

GO
CREATE PROCEDURE sp_error_crear
@IDError nvarchar(450),
@fechaYHora nvarchar(450),
@IDusuario nvarchar(450),
@mensajeDeError nvarchar(450)
AS
BEGIN
INSERT INTO Error(
IDError,
fechaYHora,
IDusuario,
mensajeDeError
)
VALUES(
@IDError,
@fechaYHora,
@IDusuario,
@mensajeDeError
);
END

-- Tabla: Error / Actualizar

GO
CREATE PROCEDURE sp_error_actualizar
@IDError nvarchar(450),
@fechaYHora nvarchar(450),
@IDusuario nvarchar(450),
@mensajeDeError nvarchar(450)
AS
BEGIN
UPDATE Error
SET
IDError = @IDError,
fechaYHora = @fechaYHora,
IDusuario = @IDusuario,
mensajeDeError = @mensajeDeError
WHERE
IDError = @IDError
END

-- Tabla: Error / Eliminar

GO
CREATE PROCEDURE sp_error_eliminar
@IDError nvarchar(450)
AS
BEGIN
DELETE Error WHERE IDError = @IDError
END

-- Tabla: Error / Leer

GO
CREATE PROCEDURE sp_error_leer
AS
BEGIN
SELECT * FROM Error
END