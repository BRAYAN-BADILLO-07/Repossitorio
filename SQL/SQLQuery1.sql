CREATE DATABASE FLunaProgramacionNCapas
go

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50),
	ApellidoPaterno VARCHAR(50),
	ApellidoMaterno VARCHAR(50),
	Sexo CHAR(2)

)