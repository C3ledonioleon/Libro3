DROP DATABASE IF EXISTS NetflixLibrosBD;
CREATE DATABASE NetflixLibrosBD;
USE NetflixLibrosBD;
-- =====================
-- Tabla Usuario
-- =====================
CREATE TABLE Usuario(
    idUsuario INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL
);

CREATE TABLE Libro (
    IdLibro INT AUTO_INCREMENT PRIMARY KEY,
    Titulo VARCHAR(200) NOT NULL,
    Autor VARCHAR(150) NOT NULL,
    Descripcion TEXT,
    Genero VARCHAR(100),
    PortadaUrl VARCHAR(300)
);
