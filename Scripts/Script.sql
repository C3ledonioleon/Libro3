DROP DATABASE IF EXISTS NetflixLibrosBD;
CREATE DATABASE NetflixLibrosBD;
USE NetflixLibrosBD;

CREATE TABLE Usuario(
    idUsuario INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Rol INT NOT NULL DEFAULT 2
);
INSERT INTO Usuario ( Email, Password, Rol )
VALUES ("admin@gmail.com" , "PrP+ZrMeO00Q+nC1ytSccRIpSvauTkdqHEBRVdRaoSE=", 1);


CREATE TABLE Libro (
    IdLibro INT AUTO_INCREMENT PRIMARY KEY,
    Titulo VARCHAR(200) NOT NULL,
    Autor VARCHAR(150) NOT NULL,
    Genero VARCHAR(100),
    Sinopsis TEXT,
    Imagen VARCHAR(300),
    UrlLibro VARCHAR (300)
);


INSERT INTO Libro ( Titulo, Autor, Genero, Sinopsis, Imagen, UrlLibro )
VALUES 
('LOS JUEGOS DEL HAMBRE','Suzanne Collins','Ciencia Ficción, Aventura, Drama y Romance',
    'presenta a Katniss Everdeen, una adolescente de 16 años en la nación postapocalíptica de Panem, donde el rico Capitolio obliga a 12 distritos empobrecidos a enviar un chico y una chica ("tributos")
    a un combate a muerte televisado anualmente, y Katniss se ofrece voluntaria para salvar a su hermana menor, Prim, enfrentándose a su destino junto al tributo masculino, Peeta Mellark, en una lucha por la supervivencia y el desafío al sistema',
    '/Imagenes/200ba89e-853f-4892-b5a2-db92205e97b5.webp',"https://fhs.trusd.net/documents/Library/Ebooks/the%20hunger%20games%20in%20spanish.pdf"
    
);



