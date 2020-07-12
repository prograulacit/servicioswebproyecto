
-- Tabla: Generos_Pelicula / Insertar 

GO
CREATE PROCEDURE sp_generos_pelicula_crear
@IDgeneroPeli nvarchar(450),
@genero nvarchar(450)
AS
BEGIN
INSERT INTO Generos_Pelicula(
IDgeneroPeli,
genero
)
VALUES(
@IDgeneroPeli,
@genero
);
END

-- Tabla: Generos_Pelicula / Actualizar

GO
CREATE PROCEDURE sp_generos_pelicula_actualizar
@IDgeneroPeli nvarchar(450),
@genero nvarchar(450)
AS
BEGIN
UPDATE Generos_Pelicula
SET
IDgeneroPeli = @IDgeneroPeli,
genero = @genero
WHERE
IDgeneroPeli = @IDgeneroPeli
END

-- Tabla: Generos_Pelicula / Eliminar

GO
CREATE PROCEDURE sp_generos_pelicula_eliminar
@IDgeneroPeli nvarchar(450)
AS
BEGIN
DELETE Generos_Pelicula WHERE IDgeneroPeli = @IDgeneroPeli
END

-- Tabla: Generos_Pelicula / Leer

GO
CREATE PROCEDURE sp_generos_pelicula_leer
AS
BEGIN
SELECT * FROM Generos_Pelicula
END