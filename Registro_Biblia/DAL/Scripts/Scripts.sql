CREATE DATABASE LibrosDb
GO
USE LibrosDb
GO
CREATE TABLE Libros
(
	LibroId int primary key identity (1,1),
	Descripcion varchar(30),
	Siglas varchar(13),
	TipoId int,
);