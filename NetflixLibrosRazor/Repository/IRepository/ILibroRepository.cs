using NetflixLibrosRazor.Models;
using NetflixLibrosRazor.Repositories;

namespace NetflixLibrosRazor.Repository.IRepository;

public interface ILibroRepository
{
    List<Libro> GetAll();
    Libro? GetById(int id);
    int Add( LibroCreateDto libro);
    int Update(int id, LibroUpdateDto libro);
    int Delete(int id);
}