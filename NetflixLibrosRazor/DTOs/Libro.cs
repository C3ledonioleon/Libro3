public class LibroCreateDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Sinopsis { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string Imagen { get; set; } = string.Empty;
    public string UrlLibro { get; set; } = string.Empty; // NUEVO
}

public class LibroUpdateDto : LibroCreateDto
{
    // Hereda todas las propiedades de LibroCreateDto
}
public class LibroDto
{
    public int IdLibro { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Sinopsis { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string Imagen { get; set; } = string.Empty;
    public string UrlLibro { get; set; } = string.Empty; // NUEVO
}