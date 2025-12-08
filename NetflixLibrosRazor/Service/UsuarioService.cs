using System.Security.Cryptography;
using System.Text;
using NetflixLibrosRazor.DTOs;
using NetflixLibrosRazor.Models;

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
            Password = HashPassword(registerDto.Contraseña),
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

}

