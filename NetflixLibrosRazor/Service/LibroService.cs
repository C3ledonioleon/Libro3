using NetflixLibrosRazor.Models;
using NetflixLibrosRazor.Repository.IRepository;

namespace NetflixLibrosRazor.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _repo;

        public LibroService(ILibroRepository repo)
        {
            _repo = repo;
        }

        public List<LibroDto> ObtenerTodo()
        {
            var libros = _repo.GetAll();

            return libros.Select(l => new LibroDto
            {
                IdLibro = l.IdLibro,
                Titulo = l.Titulo,
                Autor = l.Autor,
                Descripcion = l.Descripcion,
                Genero = l.Genero,
                PortadaUrl = l.PortadaUrl
            }).ToList();
        }

        public Libro? ObtenerPorId(int id)
        {
            return _repo.GetById(id);
        }

        public int AgregarLibro(LibroCreateDto dto)
        {
            var libro = new Libro
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                Descripcion = dto.Descripcion,
                Genero = dto.Genero,
                PortadaUrl = dto.PortadaUrl
            };

            return _repo.Add(dto);
        }

        public int ActualizarLibro(int id, LibroUpdateDto dto)
        {
            var libro = new Libro
            {
                IdLibro = id,            // El ID viene por parámetro
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                Descripcion = dto.Descripcion,
                Genero = dto.Genero,
                PortadaUrl = dto.PortadaUrl
            };

            return _repo.Update(id, dto);
        }

        public int EliminarLibro(int id)
        {
            return _repo.Delete(id);
        }
    }
}
