using Dapper;
using NetflixLibrosRazor.Models;
using NetflixLibrosRazor.Repository.Factories;
using NetflixLibrosRazor.Repository.IRepository;


public class LibroRepository : ILibroRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public LibroRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public List<Libro> GetAll()
    {
        using var connection = _connectionFactory.CreateConnection();
        return connection.Query<Libro>("SELECT * FROM Libro").ToList();
    }

    public Libro? GetById(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        return connection.QueryFirstOrDefault<Libro>(
            "SELECT * FROM Libro WHERE IdLibro = @IdLibro",
            new { IdLibro = id }
        );
    }

    public int Add(LibroCreateDto libro)
    {
        using var connection = _connectionFactory.CreateConnection();

        string sql = @"
            INSERT INTO Libro (Titulo, Autor, Sinopsis, Genero, Imagen, UrlLibro)
            VALUES (@Titulo, @Autor, @Sinopsis, @Genero, @Imagen, @UrlLibro);
            SELECT LAST_INSERT_ID();";

        int newId = connection.ExecuteScalar<int>(sql, libro);

        return newId;
    }

    public int Update(int id, LibroUpdateDto libro)
    {
        using var connection = _connectionFactory.CreateConnection();

        string sql = @"
            UPDATE Libro
            SET Titulo = @Titulo,
                Autor = @Autor,
                Sinopsis = @Sinopsis,
                Genero = @Genero,
                Imagen = @Imagen,
                UrlLibro = @UrlLibro
            WHERE IdLibro = @IdLibro";
        int rows = connection.Execute(sql, new { IdLibro = id });
        return rows > 0 ? id : 0; ;
    }

    public int Delete(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        string sql = "DELETE FROM Libro WHERE IdLibro = @IdLibro";

        int rows = connection.Execute(sql, new { IdLibro = id });

        return rows > 0 ? id : 0;
    }

}
