public class LibroCreateDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string PortadaUrl { get; set; } = string.Empty;
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
    public string Descripcion { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string PortadaUrl { get; set; } = string.Empty;
}