using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetflixLibrosRazor.Models;
using NetflixLibrosRazor.Services;
using System.Collections.Generic;

namespace NetflixLibrosRazor.Pages.Admin
{
    public class UsuariosModel : PageModel
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosModel(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public string Mensaje { get; set; } = string.Empty;
        public int? RolUsuarioActual { get; set; }

        public IActionResult OnGet()
        {
            // Verificar que el usuario sea administrador
            var rolSession = HttpContext.Session.GetInt32("UsuarioRol");
            if (rolSession == null || rolSession != (int)RolUsuario.Administrador)
            {
                TempData["Error"] = "No tienes permisos para acceder a esta página.";
                return RedirectToPage("/Libros/Index");
            }

            RolUsuarioActual = rolSession;
            Usuarios = _usuarioService.ObtenerTodos();
            return Page();
        }

        public IActionResult OnPostEliminar(int id)
        {
            // Verificar que el usuario sea administrador
            var rolSession = HttpContext.Session.GetInt32("UsuarioRol");
            if (rolSession == null || rolSession != (int)RolUsuario.Administrador)
            {
                TempData["Error"] = "No tienes permisos para eliminar usuarios.";
                return RedirectToPage();
            }

            try
            {
                var resultado = _usuarioService.DeleteUsuario(id, rolSession.Value);
                if (resultado > 0)
                {
                    TempData["Success"] = "Usuario eliminado correctamente.";
                }
                else
                {
                    TempData["Error"] = "No se pudo eliminar el usuario.";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar: " + ex.Message;
            }

            return RedirectToPage();
        }
    }
}
