

CREATE TABLE Consecutivo(
	ID varchar(20) PRIMARY KEY,
	tipoConsecutivo varchar(100),
	descripcion varchar(60),
	prefijo varchar(5),
	rangoInicial int NOT NULL,
	rangoFinal int NOT NULL
);


CREATE TABLE Generos_Pelicula(
	IDgeneroPeli varchar(20) PRIMARY KEY,
	genero varchar(100)
);

CREATE TABLE Generos_Musica(
	IDgeneroMus varchar(20) PRIMARY KEY,
	genero varchar(100)
);

CREATE TABLE Generos_Libros(
	IDcategoriaLib varchar(20) PRIMARY KEY,
	categoria varchar(100)
);

CREATE TABLE Pelicula(
	ID varchar(20) FOREIGN KEY REFERENCES Consecutivo(ID),
	nombre varchar NOT NULL PRIMARY KEY,
	IDgenero varchar(20) FOREIGN KEY REFERENCES Generos_Pelicula(IDgeneroPeli),
	anio varchar(100),
	idioma varchar(100),
	actores varchar(100),
	nombreArchivoDescarga varchar NOT NULL,
	nombreArchivoPrevisualizacion varchar NOT NULL,
	monto decimal(18,2)
);

CREATE TABLE Musica(
	ID varchar(20) FOREIGN KEY REFERENCES Consecutivo(ID),
	nombre varchar NOT NULL PRIMARY KEY,
	IDgenero varchar(20) FOREIGN KEY REFERENCES Generos_Musica(IDgeneroMus),
	tipoInterpretacion varchar(100),
	pais varchar(100),
	anio varchar(100),
	idioma varchar(100),
	diquera varchar(100),
	nombreDisco varchar(100),
	nombreArchivoDescarga varchar NOT NULL,
	nombreArchivoPrevisualizacion varchar NOT NULL,
	monto decimal(18,2)
);


CREATE TABLE Libro(
	ID varchar(20) FOREIGN KEY REFERENCES Consecutivo(ID),
	nombre varchar NOT NULL PRIMARY KEY,
	IDcategoria varchar(20) FOREIGN KEY REFERENCES Generos_Libros(IDcategoriaLib),
	autor varchar(100),
	idioma varchar(100),
	editorial varchar(100),
	anioPublicacion varchar(100),
	nombreArchivoDescarga varchar NOT NULL,
	nombreArchivoPrevisualizacion varchar NOT NULL,
	monto decimal(18,2)
);


CREATE TABLE Usuario(
	ID varchar(20) FOREIGN KEY REFERENCES Consecutivo(ID),
	IDusuario varchar(100) PRIMARY KEY,
	nombre varchar(100),
	primerApellido varchar(100),
	SegundoApellido varchar(100),
	correoElectronico varchar(100),
	nombreUsuario varchar(100),
	contrasenia varchar(100)
);


CREATE TABLE Transaccion(
	IDusuario varchar(100) FOREIGN KEY REFERENCES Usuario(IDusuario),
	IDcompra varchar(100) PRIMARY KEY,
	monto varchar(100),
	fechaCompra date,
	IDtarjeta int NOT NULL,
);


CREATE TABLE Administrador(
	ID varchar(20) FOREIGN KEY REFERENCES Consecutivo(ID),
	IDadmin varchar(100) PRIMARY KEY,
	nombreUsuario varchar(100),
	contrasenia varchar(100),
	correoElectronico varchar(100),
	preguntaSeguridad varchar(100),
	respuestaSeguridad varchar(100),
	adminMaestro BIT,
	adminSeguridad BIT,
	adminMantenimiento BIT,
	adminConsultas BIT
);

CREATE TABLE Bitacora(
	ID varchar(20) FOREIGN KEY REFERENCES Consecutivo(ID),
	IDadmin varchar(100) FOREIGN KEY REFERENCES administrador(IDadmin),
	fechaYHora datetime,
	codigoDelRegistro varchar(100) PRIMARY KEY,
	tipo varchar(100),
	descripcion varchar(100),
	registroEnDetalle varchar(100)
);


CREATE TABLE tarjeta(
	numeroTarjeta int PRIMARY KEY,
	IDusuario varchar(100),
	mesExpiracion varchar(100),
	anioExpiracion varchar(100),
	CVV varchar(5),
	monto decimal(18,2),
	tipo varchar(100)
);

CREATE TABLE easypay(
	numerocuenta varchar(100) PRIMARY KEY,
	IDusuario varchar(100),
	codigoSeguridad varchar(100),
	contrasenia varchar(100),
	monto decimal(18,2),
);


CREATE TABLE parametros(
	ID varchar(100) PRIMARY KEY,
	rutasAlmacenamientoPrevisualizacionLibros varchar(150),
	rutasAlmacenamientoLibros varchar(150),
	rutasAlmacenamientoPrevisualizacionPeliculas varchar(150),
	rutasAlmacenamientoPeliculas varchar(150),
	rutasAlmacenamientoPrevisualizacionMusica varchar(150),
	rutasAlmacenamientoMusica varchar(150),
	
);