using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetflixLibrosRazor.DTOs;
using NetflixLibrosRazor.Services;

namespace NetflixLibrosRazor.Pages.Libros
{
    public class CrearModel : PageModel
    {
        private readonly ILibroService _libroService;

        public CrearModel(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [BindProperty]
        public LibroCreateDto Libro { get; set; } = new LibroCreateDto();

        public string Mensaje { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                _libroService.AgregarLibro(Libro);
                return RedirectToPage("/Libros/Lista");
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return Page();
            }
        }
    }
}
