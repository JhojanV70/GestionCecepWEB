using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionCecepWEB.Pages.Cursos
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
            ViewData["Profesores"] = new SelectList(_context.Profesores, "IdProfesor", "Nombre");
            return Page();
        }

        [BindProperty]
        public Curso Curso { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cursos.Add(Curso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}