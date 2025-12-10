using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetflixLibrosRazor.DTOs;
using NetflixLibrosRazor.Services;

namespace NetflixLibrosRazor.Pages.Libros
{
    public class CreateModel : PageModel
    {
        private readonly ILibroService _libroService;
        private readonly IWebHostEnvironment _env;

        public CreateModel(ILibroService libroService, IWebHostEnvironment env)
        {
            _libroService = libroService;
            _env = env;
        }

        [BindProperty]
        public LibroCreateDto Libro { get; set; } = new();

        [BindProperty]
        public IFormFile? ImagenFile { get; set; }

        public IActionResult OnPost()
        {
            if (ImagenFile != null)
            {
                string carpeta = Path.Combine(_env.WebRootPath, "Imagenes");
                Directory.CreateDirectory(carpeta);

                string nombreArchivo = Guid.NewGuid() + Path.GetExtension(ImagenFile.FileName);
                string ruta = Path.Combine(carpeta, nombreArchivo);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    ImagenFile.CopyTo(stream);
                }

                // Guardamos la ruta pública para mostrarla luego (coincide con la carpeta wwwroot/Imagenes)
                Libro.Imagen = $"/Imagenes/{nombreArchivo}";
            }

            _libroService.AgregarLibro(Libro);
            return RedirectToPage("/Index");
        }
    }
}
