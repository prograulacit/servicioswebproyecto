CREATE TABLE TARJETA(
	ID nvarchar(max),
	IDusuario nvarchar(max),
	numeroTarjeta nvarchar(max),
	mesExpiracion nvarchar(max),
	anioExpiracion nvarchar(max),
	CVV nvarchar(max),
	monto nvarchar(max),
	tipo nvarchar(max)
);

CREATE TABLE EASYPAY(
	ID nvarchar(max),
	IDusuario nvarchar(max),
	numeroCuenta nvarchar(max),
	codigoSeguridad nvarchar(max),
	contrasenia nvarchar(max),
	monto nvarchar(max)
);