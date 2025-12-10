using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetflixLibrosRazor.DTOs;
using NetflixLibrosRazor.Services; // Asegúrate de importar tu servicio

namespace NetflixLibrosRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUsuarioService _usuarioService;

        public IndexModel(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [BindProperty]
        public LoginDto LoginDto { get; set; } = new();

        public string Mensaje { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(LoginDto.Email) || string.IsNullOrWhiteSpace(LoginDto.Password))
            {
                ModelState.AddModelError(string.Empty, "Debés completar el email y la contraseña.");
                return Page();
            }

            if (!LoginDto.Email.Contains("@") || !LoginDto.Email.Contains("."))
            {
                ModelState.AddModelError(string.Empty, "El correo debe ser válido e incluir '@' y '.'");
                return Page();
            }

            // Validación contra la base de datos
            if (!_usuarioService.Login(LoginDto))
            {
                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
                return Page();
            }

            // Login exitoso: guardar sesión del usuario
            var usuarioAutenticado = _usuarioService.ObtenerPorEmail(LoginDto.Email);
            
            if (usuarioAutenticado != null)
            {
                HttpContext.Session.SetString("UsuarioEmail", usuarioAutenticado.Email);
                HttpContext.Session.SetInt32("UsuarioRol", (int)usuarioAutenticado.Rol);
                HttpContext.Session.SetInt32("UsuarioId", usuarioAutenticado.IdUsuario);
            }

            return RedirectToPage("/Libros/Index");
        }
    }
}
