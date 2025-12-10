using Dapper;
using MySql.Data.MySqlClient;
using NetflixLibrosRazor.Models;
using NetflixLibrosRazor.Repository.Factories;

namespace NetflixLibrosRazor.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public UsuarioRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
        
        public Usuario? GetByEmail(string email)
        {
            using var _connection = _connectionFactory.CreateConnection();
            return _connection.QueryFirstOrDefault<Usuario>(
            "SELECT * FROM Usuario WHERE Email = @Email",
            new { Email = email });
        }

        public int Add (Usuario usuario)
        {
        using var _connection = _connectionFactory.CreateConnection();
        string sql = @"
        INSERT INTO Usuario (Email, Password, Rol)
        VALUES ( @Email, @Password, @Rol);
        SELECT LAST_INSERT_ID();";
        int newId = _connection.ExecuteScalar<int>(sql, usuario);
        usuario.IdUsuario = newId;
        return newId;

        }

        public Usuario? GetById(int id)
        {
            using var _connection = _connectionFactory.CreateConnection();
            return _connection.QueryFirstOrDefault<Usuario>(
                "SELECT * FROM Usuario WHERE IdUsuario = @IdUsuario",
                new { IdUsuario = id });
        }

        public int Delete(int id)
        {
            using var _connection = _connectionFactory.CreateConnection();
            string sql = "DELETE FROM Usuario WHERE IdUsuario = @IdUsuario";
            int rows = _connection.Execute(sql, new { IdUsuario = id });
            return rows > 0 ? id : 0;
        }

}

