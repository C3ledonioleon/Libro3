using NetflixLibrosRazor.Models;

namespace NetflixLibrosRazor.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario? GetByEmail(string email);
        int Add(Usuario usuario);
        Usuario? GetById(int id);
        int Delete(int id);
    }
}
