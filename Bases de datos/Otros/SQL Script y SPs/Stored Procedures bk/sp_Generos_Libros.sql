
-- Tabla: Generos_Libros / Insertar 

GO
CREATE PROCEDURE sp_generos_libros_crear
@IDcategoriaLib nvarchar(450),
@categoria nvarchar(450)
AS
BEGIN
INSERT INTO Generos_Libros(
IDcategoriaLib,
categoria
)
VALUES(
@IDcategoriaLib,
@categoria
);
END

-- Tabla: Generos_Libros / Actualizar

GO
CREATE PROCEDURE sp_generos_libros_actualizar
@IDcategoriaLib nvarchar(450),
@categoria nvarchar(450)
AS
BEGIN
UPDATE Generos_Libros
SET
IDcategoriaLib = @IDcategoriaLib,
categoria = @categoria
WHERE
IDcategoriaLib = @IDcategoriaLib
END

-- Tabla: Generos_Libros / Eliminar

GO
CREATE PROCEDURE sp_generos_libros_eliminar
@IDcategoriaLib nvarchar(450)
AS
BEGIN
DELETE Generos_Libros WHERE IDcategoriaLib = @IDcategoriaLib
END

-- Tabla: Generos_Libros / Leer

GO
CREATE PROCEDURE sp_generos_libros_leer
AS
BEGIN
SELECT * FROM Generos_Libros
END