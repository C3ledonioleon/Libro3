using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using NetflixLibrosRazor.Models; // Modelo Libro y enum RolUsuario


namespace NetflixLibrosRazor.Pages.Libros
{
    public class IndexLibrosModel : PageModel
    {
        private readonly ILibroService _libroService;

        public IndexLibrosModel(ILibroService libroService)
        {
            _libroService = libroService;
        }

        public List<LibroDto> Libros { get; set; } = new List<LibroDto>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        // Rol del usuario actual (1 = admin, 2 = usuario)
        public int RolUsuario { get; set; } = 2; // Usuario por defecto
        public string UsuarioEmail { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            // Verificar que el usuario esté autenticado
            var emailSession = HttpContext.Session.GetString("UsuarioEmail");
            if (string.IsNullOrEmpty(emailSession))
            {
                TempData["Error"] = "Debes iniciar sesión primero.";
                return RedirectToPage("/Index");
            }

            UsuarioEmail = emailSession;
            var rolSession = HttpContext.Session.GetInt32("UsuarioRol");
            RolUsuario = rolSession ?? 2;

            var libros = _libroService.ObtenerTodo();

            // Filtrar libros por búsqueda
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                libros = libros.Where(l =>
                    l.Titulo.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            Libros = libros;
            return Page();
        }

        // Handler para eliminar libro
        public IActionResult OnPostEliminar(int id)
        {
            // Verificar autenticación
            var emailSession = HttpContext.Session.GetString("UsuarioEmail");
            if (string.IsNullOrEmpty(emailSession))
            {
                TempData["Error"] = "Debes iniciar sesión primero.";
                return RedirectToPage("/Index");
            }

            // Obtener rol de la sesión (más seguro que usar propiedad local)
            var rolSession = HttpContext.Session.GetInt32("UsuarioRol") ?? 2; // 2 = Usuario normal
            
            // Solo admin (rol = 1) puede eliminar
            if (rolSession != 1) // 1 = Administrador
            {
                TempData["Error"] = "No tienes permisos para eliminar libros. Solo los administradores pueden hacerlo.";
                return RedirectToPage();
            }

            var libro = _libroService.ObtenerPorId(id);
            if (libro == null)
            {
                TempData["Error"] = "El libro no existe.";
                return RedirectToPage();
            }

            // Eliminar imagen del servidor si existe
            if (!string.IsNullOrEmpty(libro.Imagen))
            {
                var rutaImagen = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", libro.Imagen.TrimStart('/'));
                if (System.IO.File.Exists(rutaImagen))
                    System.IO.File.Delete(rutaImagen);
            }

            // Eliminar libro de la base de datos
            _libroService.EliminarLibro(id);

            TempData["Success"] = "Libro eliminado correctamente.";
            return RedirectToPage();
        }
    }
}
