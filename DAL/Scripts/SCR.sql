CREATE DATABASE ArticulosDb1
GO
USE ArticulosDb
GO
CREATE TABLE ArticuloS11
(
	Id int primary key identity,
	Descripcion varchar(MAX),
	Existencia varchar(100),
	Costo decimal,
	ValorInventario decimal
);