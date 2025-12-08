using System.ComponentModel.DataAnnotations;

namespace NetflixLibrosRazor.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
