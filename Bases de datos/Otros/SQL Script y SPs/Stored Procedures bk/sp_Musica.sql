
-- Tabla: Musica / Insertar 

GO
CREATE PROCEDURE sp_musica_crear
@ID nvarchar(450),
@nombre nvarchar(450),
@IDgenero nvarchar(450),
@tipoInterpretacion nvarchar(450),
@pais nvarchar(450),
@anio nvarchar(450),
@idioma nvarchar(450),
@diquera nvarchar(450),
@nombreDisco nvarchar(450),
@nombreArchivoDescarga nvarchar(450),
@nombreArchivoPrevisualizacion nvarchar(450),
@monto nvarchar(450)
AS
BEGIN
INSERT INTO Musica(
ID,
nombre,
IDgenero,
tipoInterpretacion,
pais,
anio,
idioma,
diquera,
nombreDisco,
nombreArchivoDescarga,
nombreArchivoPrevisualizacion,
monto
)
VALUES(
@ID,
@nombre,
@IDgenero,
@tipoInterpretacion,
@pais,
@anio,
@idioma,
@diquera,
@nombreDisco,
@nombreArchivoDescarga,
@nombreArchivoPrevisualizacion,
@monto
);
END

-- Tabla: Musica / Actualizar

GO
CREATE PROCEDURE sp_musica_actualizar
@ID nvarchar(450),
@nombre nvarchar(450),
@IDgenero nvarchar(450),
@tipoInterpretacion nvarchar(450),
@pais nvarchar(450),
@anio nvarchar(450),
@idioma nvarchar(450),
@diquera nvarchar(450),
@nombreDisco nvarchar(450),
@nombreArchivoDescarga nvarchar(450),
@nombreArchivoPrevisualizacion nvarchar(450),
@monto nvarchar(450)
AS
BEGIN
UPDATE Musica
SET
ID = @ID,
nombre = @nombre,
IDgenero = @IDgenero,
tipoInterpretacion = @tipoInterpretacion,
pais = @pais,
anio = @anio,
idioma = @idioma,
diquera = @diquera,
nombreDisco = @nombreDisco,
nombreArchivoDescarga = @nombreArchivoDescarga,
nombreArchivoPrevisualizacion = @nombreArchivoPrevisualizacion,
monto = @monto
WHERE
ID = @ID
END

-- Tabla: Musica / Eliminar

GO
CREATE PROCEDURE sp_musica_eliminar
@ID nvarchar(450)
AS
BEGIN
DELETE Musica WHERE ID = @ID
END

-- Tabla: Musica / Leer

GO
CREATE PROCEDURE sp_musica_leer
AS
BEGIN
SELECT * FROM Musica
END