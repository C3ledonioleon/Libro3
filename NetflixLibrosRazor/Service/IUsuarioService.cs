using NetflixLibrosRazor.DTOs;

namespace NetflixLibrosRazor.Services
{
    public interface IUsuarioService
    {
        int Register(RegisterDto registerDto);
        bool Login(LoginDto loginDto);
    }
}
