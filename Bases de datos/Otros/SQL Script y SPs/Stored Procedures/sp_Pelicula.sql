
-- Tabla: Pelicula / Insertar 

GO
CREATE PROCEDURE sp_pelicula_crear
@ID nvarchar(450),
@nombre nvarchar(450),
@IDgenero nvarchar(450),
@anio nvarchar(450),
@idioma nvarchar(450),
@actores nvarchar(450),
@nombreArchivoDescarga nvarchar(450),
@nombreArchivoPrevisualizacion nvarchar(450),
@monto nvarchar(450)
AS
BEGIN
INSERT INTO Pelicula(
ID,
nombre,
IDgenero,
anio,
idioma,
actores,
nombreArchivoDescarga,
nombreArchivoPrevisualizacion,
monto
)
VALUES(
@ID,
@nombre,
@IDgenero,
@anio,
@idioma,
@actores,
@nombreArchivoDescarga,
@nombreArchivoPrevisualizacion,
@monto
);
END

-- Tabla: Pelicula / Actualizar

GO
CREATE PROCEDURE sp_pelicula_actualizar
@ID nvarchar(450),
@nombre nvarchar(450),
@IDgenero nvarchar(450),
@anio nvarchar(450),
@idioma nvarchar(450),
@actores nvarchar(450),
@nombreArchivoDescarga nvarchar(450),
@nombreArchivoPrevisualizacion nvarchar(450),
@monto nvarchar(450)
AS
BEGIN
UPDATE Pelicula
SET
ID = @ID,
nombre = @nombre,
IDgenero = @IDgenero,
anio = @anio,
idioma = @idioma,
actores = @actores,
nombreArchivoDescarga = @nombreArchivoDescarga,
nombreArchivoPrevisualizacion = @nombreArchivoPrevisualizacion,
monto = @monto
WHERE
ID = @ID
END

-- Tabla: Pelicula / Eliminar

GO
CREATE PROCEDURE sp_pelicula_eliminar
@ID nvarchar(450)
AS
BEGIN
DELETE Pelicula WHERE ID = @ID
END

-- Tabla: Pelicula / Leer

GO
CREATE PROCEDURE sp_pelicula_leer
AS
BEGIN
SELECT * FROM Pelicula
END