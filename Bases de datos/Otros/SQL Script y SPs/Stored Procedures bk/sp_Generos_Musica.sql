
-- Tabla: Generos_Musica / Insertar 

GO
CREATE PROCEDURE sp_generos_musica_crear
@IDgeneroMus nvarchar(450),
@genero nvarchar(450)
AS
BEGIN
INSERT INTO Generos_Musica(
IDgeneroMus,
genero
)
VALUES(
@IDgeneroMus,
@genero
);
END

-- Tabla: Generos_Musica / Actualizar

GO
CREATE PROCEDURE sp_generos_musica_actualizar
@IDgeneroMus nvarchar(450),
@genero nvarchar(450)
AS
BEGIN
UPDATE Generos_Musica
SET
IDgeneroMus = @IDgeneroMus,
genero = @genero
WHERE
IDgeneroMus = @IDgeneroMus
END

-- Tabla: Generos_Musica / Eliminar

GO
CREATE PROCEDURE sp_generos_musica_eliminar
@IDgeneroMus nvarchar(450)
AS
BEGIN
DELETE Generos_Musica WHERE IDgeneroMus = @IDgeneroMus
END

-- Tabla: Generos_Musica / Leer

GO
CREATE PROCEDURE sp_generos_musica_leer
AS
BEGIN
SELECT * FROM Generos_Musica
END