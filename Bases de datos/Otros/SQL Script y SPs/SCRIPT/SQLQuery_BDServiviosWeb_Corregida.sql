

CREATE TABLE Consecutivo(
	ID nvarchar(max) PRIMARY KEY,
	tipoConsecutivo nvarchar(max),
	descripcion nvarchar(max),
	prefijo nvarchar(max),
	rangoInicial nvarchar(max) NOT NULL,
	rangoFinal nvarchar(max) NOT NULL
);


CREATE TABLE Generos_Pelicula(
	IDgeneroPeli nvarchar(max) PRIMARY KEY,
	genero nvarchar(max)
);

CREATE TABLE Generos_Musica(
	IDgeneroMus nvarchar(max) PRIMARY KEY,
	genero nvarchar(max)
);

CREATE TABLE Generos_Libros(
	IDcategoriaLib nvarchar(max) PRIMARY KEY,
	categoria nvarchar(max)
);

CREATE TABLE Pelicula(
	ID nvarchar(max) FOREIGN KEY REFERENCES Consecutivo(ID),
	nombre nvarchar(max) PRIMARY KEY,
	IDgenero nvarchar(max) FOREIGN KEY REFERENCES Generos_Pelicula(IDgeneroPeli),
	anio nvarchar(max),
	idioma nvarchar(max),
	actores nvarchar(max),
	nombreArchivoDescarga nvarchar(max) NOT NULL,
	nombreArchivoPrevisualizacion nvarchar(max) NOT NULL,
	monto nvarchar(max)
);

CREATE TABLE Musica(
	ID nvarchar(max) FOREIGN KEY REFERENCES Consecutivo(ID),
	nombre nvarchar(max) PRIMARY KEY,
	IDgenero nvarchar(max) FOREIGN KEY REFERENCES Generos_Musica(IDgeneroMus),
	tipoInterpretacion nvarchar(max),
	pais nvarchar(max),
	anio nvarchar(max),
	idioma nvarchar(max),
	diquera nvarchar(max),
	nombreDisco nvarchar(max),
	nombreArchivoDescarga nvarchar(max) NOT NULL,
	nombreArchivoPrevisualizacion nvarchar(max) NOT NULL,
	monto nvarchar(max)
);


CREATE TABLE Libro(
	ID nvarchar(max) FOREIGN KEY REFERENCES Consecutivo(ID),
	nombre nvarchar(max) PRIMARY KEY,
	IDcategoria nvarchar(max) FOREIGN KEY REFERENCES Generos_Libros(IDcategoriaLib),
	autor nvarchar(max),
	idioma nvarchar(max),
	editorial nvarchar(max),
	anioPublicacion nvarchar(max),
	nombreArchivoDescarga nvarchar(max) NOT NULL,
	nombreArchivoPrevisualizacion nvarchar(max) NOT NULL,
	monto nvarchar(max)
);


CREATE TABLE Usuario(
	ID nvarchar(max) FOREIGN KEY REFERENCES Consecutivo(ID),
	IDusuario nvarchar(max) PRIMARY KEY,
	nombre nvarchar(max),
	primerApellido nvarchar(max),
	SegundoApellido nvarchar(max),
	correoElectronico nvarchar(max),
	nombreUsuario nvarchar(max),
	contrasenia nvarchar(max),
	preguntaSeguridad nvarchar(max),
	respuestaSeguridad nvarchar(max),
	adminStatus BIT,
	adminMaestro BIT,
	adminSeguridad BIT,
	adminMantenimiento BIT,
	adminConsultas BIT
);


CREATE TABLE Transaccion(
	IDusuario nvarchar(max) FOREIGN KEY REFERENCES Usuario(IDusuario),
	IDcompra nvarchar(max) PRIMARY KEY,
	monto nvarchar(max),
	fechaCompra nvarchar(max),
	IDtarjeta nvarchar(max) NOT NULL,
);



CREATE TABLE Bitacora(
	ID nvarchar(max) FOREIGN KEY REFERENCES Consecutivo(ID),
	IDusuario nvarchar(max) FOREIGN KEY REFERENCES Usuario(IDusuario),
	fechaYHora nvarchar(max),
	codigoDelRegistro nvarchar(max) PRIMARY KEY,
	tipo nvarchar(max),
	descripcion nvarchar(max),
	registroEnDetalle nvarchar(max)
);


CREATE TABLE Descargas(
	ID nvarchar(max) FOREIGN KEY REFERENCES Consecutivo(ID),
	IDDescarga nvarchar(max) PRIMARY KEY,
	nombreDescarga nvarchar(max),
	cantidadDescarga nvarchar(max)
	
);


CREATE TABLE Tarjeta(
	numeroTarjeta nvarchar(max) PRIMARY KEY,
	IDcompra nvarchar(max) FOREIGN KEY REFERENCES Transaccion(IDcompra),
	IDusuario nvarchar(max) FOREIGN KEY REFERENCES Usuario(IDusuario),
	mesExpiracion nvarchar(max),
	anioExpiracion nvarchar(max),
	CVV nvarchar(max),
	tipo nvarchar(max)
);

CREATE TABLE Easypay(
	numerocuenta nvarchar(max) PRIMARY KEY,
	IDcompra nvarchar(max) FOREIGN KEY REFERENCES Transaccion(IDcompra),
	IDusuario nvarchar(max) FOREIGN KEY REFERENCES Usuario(IDusuario),
	codigoSeguridad nvarchar(max),
	contrasenia nvarchar(max)
);


CREATE TABLE Error(
	IDError nvarchar(max) PRIMARY KEY,
	fechaYHora nvarchar(max),
	IDusuario nvarchar(max) FOREIGN KEY REFERENCES Usuario(IDusuario),
	mensajeDeError nvarchar(max)
);


CREATE TABLE Parametros(
	ID nvarchar(max) PRIMARY KEY,
	rutasAlmacenamientoPrevisualizacionLibros nvarchar(max),
	rutasAlmacenamientoLibros nvarchar(max),
	rutasAlmacenamientoPrevisualizacionPeliculas nvarchar(max),
	rutasAlmacenamientoPeliculas nvarchar(max),
	rutasAlmacenamientoPrevisualizacionMusica nvarchar(max),
	rutasAlmacenamientoMusica nvarchar(max)
);