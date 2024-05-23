using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionCecepWEB.Pages.Calificaciones
{
    public class CreateModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public CreateModel(GestionCecepContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Calificacion Calificacion { get; set; }

        public SelectList Estudiantes { get; set; }
        public SelectList Cursos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Estudiantes = new SelectList(_context.Estudiantes, "IdEstudiante", "Nombre");
            Cursos = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Estudiantes = new SelectList(_context.Estudiantes, "IdEstudiante", "Nombre");
                Cursos = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");
                return Page();
            }

            _context.Calificaciones.Add(Calificacion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
    