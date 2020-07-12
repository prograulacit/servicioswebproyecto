
-- Tabla: Parametros / Insertar 

GO
CREATE PROCEDURE sp_parametros_crear
@ID nvarchar(450),
@rutasAlmacenamientoPrevisualizacionLibros nvarchar(450),
@rutasAlmacenamientoLibros nvarchar(450),
@rutasAlmacenamientoPrevisualizacionPeliculas nvarchar(450),
@rutasAlmacenamientoPeliculas nvarchar(450),
@rutasAlmacenamientoPrevisualizacionMusica nvarchar(450),
@rutasAlmacenamientoMusica nvarchar(450)
AS
BEGIN
INSERT INTO Parametros(
ID,
rutasAlmacenamientoPrevisualizacionLibros,
rutasAlmacenamientoLibros,
rutasAlmacenamientoPrevisualizacionPeliculas,
rutasAlmacenamientoPeliculas,
rutasAlmacenamientoPrevisualizacionMusica,
rutasAlmacenamientoMusica
)
VALUES(
@ID,
@rutasAlmacenamientoPrevisualizacionLibros,
@rutasAlmacenamientoLibros,
@rutasAlmacenamientoPrevisualizacionPeliculas,
@rutasAlmacenamientoPeliculas,
@rutasAlmacenamientoPrevisualizacionMusica,
@rutasAlmacenamientoMusica
);
END

-- Tabla: Parametros / Actualizar

GO
CREATE PROCEDURE sp_parametros_actualizar
@ID nvarchar(450),
@rutasAlmacenamientoPrevisualizacionLibros nvarchar(450),
@rutasAlmacenamientoLibros nvarchar(450),
@rutasAlmacenamientoPrevisualizacionPeliculas nvarchar(450),
@rutasAlmacenamientoPeliculas nvarchar(450),
@rutasAlmacenamientoPrevisualizacionMusica nvarchar(450),
@rutasAlmacenamientoMusica nvarchar(450)
AS
BEGIN
UPDATE Parametros
SET
ID = @ID,
rutasAlmacenamientoPrevisualizacionLibros = @rutasAlmacenamientoPrevisualizacionLibros,
rutasAlmacenamientoLibros = @rutasAlmacenamientoLibros,
rutasAlmacenamientoPrevisualizacionPeliculas = @rutasAlmacenamientoPrevisualizacionPeliculas,
rutasAlmacenamientoPeliculas = @rutasAlmacenamientoPeliculas,
rutasAlmacenamientoPrevisualizacionMusica = @rutasAlmacenamientoPrevisualizacionMusica,
rutasAlmacenamientoMusica = @rutasAlmacenamientoMusica
WHERE
ID = @ID
END

-- Tabla: Parametros / Eliminar

GO
CREATE PROCEDURE sp_parametros_eliminar
@ID nvarchar(450)
AS
BEGIN
DELETE Parametros WHERE ID = @ID
END

-- Tabla: Parametros / Leer

GO
CREATE PROCEDURE sp_parametros_leer
AS
BEGIN
SELECT * FROM Parametros
END