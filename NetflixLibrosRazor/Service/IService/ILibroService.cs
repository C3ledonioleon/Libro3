using NetflixLibrosRazor.Models;
using NetflixLibrosRazor.DTOs;
public interface ILibroService
{
    List<LibroDto> ObtenerTodo();   
    Libro? ObtenerPorId(int id);           // Antes: GetById
    int AgregarLibro(LibroCreateDto cliente);     // Antes: Add
    int ActualizarLibro(int id, LibroUpdateDto cliente); // Antes: Update
    int EliminarLibro(int id);   
}

