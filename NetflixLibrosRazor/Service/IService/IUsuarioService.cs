using NetflixLibrosRazor.DTOs;
using NetflixLibrosRazor.Models;

namespace NetflixLibrosRazor.Services
{
    public interface IUsuarioService
    {
        int Register(RegisterDto registerDto);
        bool Login(LoginDto loginDto);
        Usuario? ObtenerPorId(int id);
        int DeleteUsuario(int id, int rolActual);
        List<Usuario> ObtenerTodos();
        Usuario? ObtenerPorEmail(string email);
    }
}
