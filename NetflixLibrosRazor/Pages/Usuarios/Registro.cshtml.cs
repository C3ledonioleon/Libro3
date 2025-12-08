using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetflixLibrosRazor.DTOs;      // Importa tus modelos/DTOs
using NetflixLibrosRazor.Services;    // Importa tu servicio de usuarios

namespace NetflixLibrosRazor.Pages.Usuarios
{
    public class RegistroModel : PageModel
    {
        private readonly IUsuarioService _usuarioService;

        // Constructor que recibe el servicio de usuarios mediante inyección de dependencias
        public RegistroModel(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Propiedad que enlaza el formulario con el DTO de registro
        [BindProperty]
        public RegisterDto RegisterDto { get; set; } = new RegisterDto();
        public string Mensaje { get; set; } = string.Empty;
        public void OnGet()
        {
        }

        // Método que se ejecuta al enviar el formulario (POST)
        public IActionResult OnPost()
        {
            // Validar que los datos del formulario sean correctos
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Llama al servicio para registrar el usuario
                _usuarioService.Register(RegisterDto);

                // Mensaje de éxito
                Mensaje = "Usuario registrado correctamente!";

                // Redirige a la página principal
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                // Si hay error, se muestra en la misma página
                Mensaje = ex.Message;
                return Page();
            }
        }
    }
}
