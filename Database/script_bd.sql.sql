create database DbContext;
use DbContext;

CREATE TABLE Productos (
    Id INT PRIMARY KEY,
    Nombre NVARCHAR(20) NOT NULL,
    Precio INT NOT NULL,
    Categoria NVARCHAR(20)
);
select * from Productos;