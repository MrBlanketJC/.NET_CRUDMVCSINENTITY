create table Empleados (
	IDEmpleados int primary key identity,
	Apellidos varchar(50),
	Nombres varchar(50),
	Telefono varchar(50),
	Correo varchar(50),
	Pais varchar(50),
	Provincia varchar(50),
	Canton varchar(50),
	Direccion varchar(50),
	Estado bit default 1
)

insert into Empleados values ('Caiza Altamirano', 'Damaris Zulay', '023669988', 'dcaiza@corrreo.com', 'Ecuador', 'Pichincha', 'Quito', 'Vist hermonsa N5-6', 1)


declare @apellidos nvarchar(50) ='Zambrano'
declare @nombres nvarchar(50) ='Marco'
declare @telefono nvarchar(50) ='09999999'
declare @correo nvarchar(50) ='mzambrano@domain.com'
declare @pais nvarchar(50) ='Colombia'
declare @provincia nvarchar(50) ='Yucaten'
declare @canton nvarchar(50) ='Medellin'
declare @direccion nvarchar(50) ='Colombia N897-8'

insert into Empleados (Apellidos, Nombres, Telefono, Correo, Pais, Provincia, Canton, Direccion, Estado)values(@apellidos, @nombres, @telefono, @correo, @pais, @provincia, @canton, @direccion, 1)