namespace NetflixLibrosRazor.Models;
public class Libro
{
    public int IdLibro { get; set; } // Identificador único del libro
    public string Titulo { get; set; } = string.Empty; // Título del libro
    public string Autor { get; set; } = string.Empty; // Autor o autores del libro
    public string Sinopsis { get; set; } = string.Empty; // Descripción o sinopsis del libro
    public string Genero { get; set; } = string.Empty; // Género o categoría del libro
    public string Imagen { get; set; } = string.Empty;
    public string UrlLibro { get; set; } = string.Empty; // NUEVO
}