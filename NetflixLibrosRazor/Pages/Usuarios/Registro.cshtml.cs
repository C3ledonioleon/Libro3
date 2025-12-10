using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetflixLibrosRazor.DTOs;      // Importa tus modelos/DTOs
using NetflixLibrosRazor.Services;    // Importa tu servicio de usuarios

namespace NetflixLibrosRazor.Pages.Usuarios
{
    public class RegistroModel : PageModel
    {
        private readonly IUsuarioService _usuarioService;

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
                // Llama al servicio para registrar el usuario y obtener el id
                var id = _usuarioService.Register(RegisterDto);

                if (id > 0)
                {
                    // Mensaje de éxito (puede mostrarse antes de redirigir o guardarse en TempData)
                    TempData["RegistroExito"] = "Usuario registrado correctamente.";
                    return RedirectToPage("/Index");
                }
                else
                {
                    Mensaje = "No se pudo registrar el usuario. Intente nuevamente.";
                    return Page();
                }
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
