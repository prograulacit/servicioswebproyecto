

CREATE TABLE Consecutivo(
	ID nvarchar(450) PRIMARY KEY,
	tipoConsecutivo nvarchar(450),
	descripcion nvarchar(450),
	prefijo nvarchar(450),
	rangoInicial nvarchar(450) NOT NULL,
	rangoFinal nvarchar(450) NOT NULL
);


CREATE TABLE Generos_Pelicula(
	IDgeneroPeli nvarchar(450) PRIMARY KEY,
	genero nvarchar(450)
);

CREATE TABLE Generos_Musica(
	IDgeneroMus nvarchar(450) PRIMARY KEY,
	genero nvarchar(450)
);

CREATE TABLE Generos_Libros(
	IDcategoriaLib nvarchar(450) PRIMARY KEY,
	categoria nvarchar(450)
);

CREATE TABLE Pelicula(
	ID nvarchar(450) FOREIGN KEY REFERENCES Consecutivo(ID),
	nombre nvarchar(450) PRIMARY KEY,
	IDgenero nvarchar(450) FOREIGN KEY REFERENCES Generos_Pelicula(IDgeneroPeli),
	anio nvarchar(450),
	idioma nvarchar(450),
	actores nvarchar(450),
	nombreArchivoDescarga nvarchar(450) NOT NULL,
	nombreArchivoPrevisualizacion nvarchar(450) NOT NULL,
	monto nvarchar(450)
);

CREATE TABLE Musica(
	ID nvarchar(450) FOREIGN KEY REFERENCES Consecutivo(ID),
	nombre nvarchar(450) PRIMARY KEY,
	IDgenero nvarchar(450) FOREIGN KEY REFERENCES Generos_Musica(IDgeneroMus),
	tipoInterpretacion nvarchar(450),
	pais nvarchar(450),
	anio nvarchar(450),
	idioma nvarchar(450),
	diquera nvarchar(450),
	nombreDisco nvarchar(450),
	nombreArchivoDescarga nvarchar(450) NOT NULL,
	nombreArchivoPrevisualizacion nvarchar(450) NOT NULL,
	monto nvarchar(450)
);


CREATE TABLE Libro(
	ID nvarchar(450) FOREIGN KEY REFERENCES Consecutivo(ID),
	nombre nvarchar(450) PRIMARY KEY,
	IDcategoria nvarchar(450) FOREIGN KEY REFERENCES Generos_Libros(IDcategoriaLib),
	autor nvarchar(450),
	idioma nvarchar(450),
	editorial nvarchar(450),
	anioPublicacion nvarchar(450),
	nombreArchivoDescarga nvarchar(450) NOT NULL,
	nombreArchivoPrevisualizacion nvarchar(450) NOT NULL,
	monto nvarchar(450)
);


CREATE TABLE Usuario(
	ID nvarchar(450) FOREIGN KEY REFERENCES Consecutivo(ID),
	IDusuario nvarchar(450) PRIMARY KEY,
	nombre nvarchar(450),
	primerApellido nvarchar(450),
	SegundoApellido nvarchar(450),
	correoElectronico nvarchar(450),
	nombreUsuario nvarchar(450),
	contrasenia nvarchar(450),
	preguntaSeguridad nvarchar(450),
	respuestaSeguridad nvarchar(450),
	adminStatus BIT,
	adminMaestro BIT,
	adminSeguridad BIT,
	adminMantenimiento BIT,
	adminConsultas BIT
);


CREATE TABLE Transaccion(
	IDusuario nvarchar(450) FOREIGN KEY REFERENCES Usuario(IDusuario),
	IDcompra nvarchar(450) PRIMARY KEY,
	monto nvarchar(450),
	fechaCompra nvarchar(450),
	IDtarjeta nvarchar(450) NOT NULL,
);



CREATE TABLE Bitacora(
	ID nvarchar(450) FOREIGN KEY REFERENCES Consecutivo(ID),
	IDusuario nvarchar(450) FOREIGN KEY REFERENCES Usuario(IDusuario),
	fechaYHora nvarchar(450),
	codigoDelRegistro nvarchar(450) PRIMARY KEY,
	tipo nvarchar(450),
	descripcion nvarchar(450),
	registroEnDetalle nvarchar(450)
);


CREATE TABLE Descargas(
	ID nvarchar(450) FOREIGN KEY REFERENCES Consecutivo(ID),
	IDDescarga nvarchar(450) PRIMARY KEY,
	nombreDescarga nvarchar(450),
	cantidadDescarga nvarchar(450)
	
);


CREATE TABLE Tarjeta(
	numeroTarjeta nvarchar(450) PRIMARY KEY,
	IDcompra nvarchar(450) FOREIGN KEY REFERENCES Transaccion(IDcompra),
	IDusuario nvarchar(450) FOREIGN KEY REFERENCES Usuario(IDusuario),
	mesExpiracion nvarchar(450),
	anioExpiracion nvarchar(450),
	CVV nvarchar(450),
	tipo nvarchar(450)
);

CREATE TABLE Easypay(
	numerocuenta nvarchar(450) PRIMARY KEY,
	IDcompra nvarchar(450) FOREIGN KEY REFERENCES Transaccion(IDcompra),
	IDusuario nvarchar(450) FOREIGN KEY REFERENCES Usuario(IDusuario),
	codigoSeguridad nvarchar(450),
	contrasenia nvarchar(450)
);


CREATE TABLE Error(
	IDError nvarchar(450) PRIMARY KEY,
	fechaYHora nvarchar(450),
	IDusuario nvarchar(450) FOREIGN KEY REFERENCES Usuario(IDusuario),
	mensajeDeError nvarchar(450)
);


CREATE TABLE Parametros(
	ID nvarchar(450) PRIMARY KEY,
	rutasAlmacenamientoPrevisualizacionLibros nvarchar(450),
	rutasAlmacenamientoLibros nvarchar(450),
	rutasAlmacenamientoPrevisualizacionPeliculas nvarchar(450),
	rutasAlmacenamientoPeliculas nvarchar(450),
	rutasAlmacenamientoPrevisualizacionMusica nvarchar(450),
	rutasAlmacenamientoMusica nvarchar(450)
);