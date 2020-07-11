CREATE TABLE TARJETA(
	ID nvarchar(max),
	numeroTarjeta nvarchar(max),
	IDusuario nvarchar(max),
	mesExpiracion nvarchar(max),
	anioExpiracion nvarchar(max),
	CVV nvarchar(max),
	monto nvarchar(max),
	tipo nvarchar(max)
);

CREATE TABLE EASYPAY(
	ID nvarchar(max),
	numerocuenta nvarchar(max),
	IDusuario nvarchar(max),
	codigoSeguridad nvarchar(max),
	contrasenia nvarchar(max),
	monto nvarchar(max)
);