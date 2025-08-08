CREATE DATABASE ProyectoEvaluacionDb;
GO
USE ProyectoEvaluacionDb;
GO

--Tabla Grupo
CREATE TABLE Grupo (
    IdGrupo INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL
);

--Tabla Usuario
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    ContraseniaHash NVARCHAR(255) NOT NULL,
    IdGrupo INT NOT NULL,
    FOREIGN KEY (IdGrupo) REFERENCES Grupo(IdGrupo)
);

--Tabla Producto
CREATE TABLE Producto (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

--Tabla Material
CREATE TABLE Formula (
    IdFormula INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Unidad NVARCHAR(20) NOT NULL
);

--Tabla FormulaMateriales
CREATE TABLE FormulaMaterial (
    IdFormulaMaterial INT PRIMARY KEY IDENTITY(1,1),
    IdFormula INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IdFormula) REFERENCES Formula(IdFormula),
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);

--Grupos
INSERT INTO Grupo (Nombre) VALUES ('Admin'), ('Producción'), ('Ventas');

--Usuarios
INSERT INTO Usuario (Nombre, ContraseniaHash, IdGrupo)
VALUES 
('jose', 'hashedpassword123', 1),
('ana', 'hashedpassword456', 2),
('luis', 'hashedpassword789', 3);

--Productos
INSERT INTO Producto (Nombre)
VALUES ('Fórmula Shampoo');

--Formula
INSERT INTO Formula (Nombre,Unidad)
VALUES
('Agua', 'ml'),
('Fragancia', 'ml'),
('Colorante', 'ml');

--Materiales para la formula
INSERT INTO FormulaMaterial (IdFormula, IdProducto, Cantidad)
VALUES 
(1, 1, 500),  -- Agua
(2, 1, 50),   -- Fragancia
(3, 1, 200);  -- Colorante

--Indice en Usuario.Nombre para busquedas
CREATE NONCLUSTERED INDEX IX_Usuario_Nombre ON Usuario(Nombre);

-- Indice en Producto.Nombre
CREATE NONCLUSTERED INDEX IX_Producto_Nombre ON Producto(Nombre);

