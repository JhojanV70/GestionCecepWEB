using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionCecepWEB.Pages.Horarios
{
    public class CreateModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public CreateModel(GestionCecepContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            // Cargar la lista de cursos y asignarla a ViewData
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");
            return Page();
        }
        /*public IActionResult OnGet()
        {
            return Page();
        }*/

        [BindProperty]
        public Horario Horario { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Horarios == null || Horario == null)
            {
                return Page();
            }

            _context.Horarios.Add(Horario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
