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