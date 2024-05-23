using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionCecepWEB.Pages.Estudiantes
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

       /* public IActionResult OnGet()
        {
            return Page();
        }*/

        [BindProperty]
        public Estudiante Estudiante { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {

            
            if (!ModelState.IsValid || _context.Estudiantes == null || Estudiante == null)
             {
                 return Page();
             }

            _context.Estudiantes.Add(Estudiante);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
          
        }   
    }
}
