using System.Security.Cryptography;
using System.Text;
using NetflixLibrosRazor.DTOs;
using NetflixLibrosRazor.Models;
using MySql.Data.MySqlClient;
using Dapper;
using NetflixLibrosRazor.Repositories;
namespace NetflixLibrosRazor.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _configuration;

    public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
    }

    public int Register(RegisterDto registerDto)
    {
        if (_usuarioRepository.GetByEmail(registerDto.Email) != null)
            throw new Exception("El email ya está registrado.");

        var usuario = new Usuario
        {
            Email = registerDto.Email,
            Password = HashPassword(registerDto.Password),
            Rol = RolUsuario.Usuario
        };
        
        return _usuarioRepository.Add(usuario);
    }

        private string HashPassword(string contraseña)
        {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(contraseña);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
        }
    public bool Login(LoginDto loginDto)
    {
        var usuario = _usuarioRepository.GetByEmail(loginDto.Email);
        if (usuario == null)
            return false;

        var hashedInputPassword = HashPassword(loginDto.Password);
        return usuario.Password == hashedInputPassword;
    }

    public Usuario? ObtenerPorId(int id)
    {
         return _usuarioRepository.GetById(id);
    }

    public int DeleteUsuario(int id, int rolActual)
    {
        // Solo administrador (rol = 1) puede eliminar usuarios
        if (rolActual != (int)RolUsuario.Administrador)
            throw new UnauthorizedAccessException("No tienes permisos para eliminar usuarios. Solo el administrador puede hacerlo.");

        return _usuarioRepository.Delete(id);
    }

    public List<Usuario> ObtenerTodos()
    {
        using var connection = new MySqlConnection(_configuration.GetConnectionString("myBD"));
        var usuarios = connection.Query<Usuario>("SELECT * FROM Usuario ORDER BY Email").ToList();
        return usuarios;
    }

    public Usuario? ObtenerPorEmail(string email)
    {
        return _usuarioRepository.GetByEmail(email);
    }
}

