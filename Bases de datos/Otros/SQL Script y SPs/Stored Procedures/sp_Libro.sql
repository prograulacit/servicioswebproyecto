
-- Tabla: Libro / Insertar 

GO
CREATE PROCEDURE sp_libro_crear
@ID nvarchar(450),
@nombre nvarchar(450),
@IDcategoria nvarchar(450),
@autor nvarchar(450),
@idioma nvarchar(450),
@editorial nvarchar(450),
@anioPublicacion nvarchar(450),
@nombreArchivoDescarga nvarchar(450),
@nombreArchivoPrevisualizacion nvarchar(450),
@monto nvarchar(450)
AS
BEGIN
INSERT INTO Libro(
ID,
nombre,
IDcategoria,
autor,
idioma,
editorial,
anioPublicacion,
nombreArchivoDescarga ,
nombreArchivoPrevisualizacion,
monto
)
VALUES(
@ID,
@nombre,
@IDcategoria,
@autor,
@idioma,
@editorial,
@anioPublicacion,
@nombreArchivoDescarga ,
@nombreArchivoPrevisualizacion,
@monto
);
END

-- Tabla: Libro / Actualizar

GO
CREATE PROCEDURE sp_libro_actualizar
@ID nvarchar(450),
@nombre nvarchar(450),
@IDcategoria nvarchar(450),
@autor nvarchar(450),
@idioma nvarchar(450),
@editorial nvarchar(450),
@anioPublicacion nvarchar(450),
@nombreArchivoDescarga nvarchar(450),
@nombreArchivoPrevisualizacion nvarchar(450),
@monto nvarchar(450)
AS
BEGIN
UPDATE Libro
SET
ID = @ID,
nombre = @nombre,
IDcategoria = @IDcategoria,
autor = @autor,
idioma = @idioma,
editorial = @editorial,
anioPublicacion = @anioPublicacion,
nombreArchivoDescarga = @nombreArchivoDescarga ,
nombreArchivoPrevisualizacion = @nombreArchivoPrevisualizacion,
monto = @monto
WHERE
ID = @ID
END

-- Tabla: Libro / Eliminar

GO
CREATE PROCEDURE sp_libro_eliminar
@ID nvarchar(450)
AS
BEGIN
DELETE Libro WHERE ID = @ID
END

-- Tabla: Libro / Leer

GO
CREATE PROCEDURE sp_libro_leer
AS
BEGIN
SELECT * FROM Libro
END