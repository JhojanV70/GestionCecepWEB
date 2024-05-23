using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Calificaciones
{
    public class EditModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public EditModel(GestionCecepContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Calificacion Calificacion { get; set; }

        public SelectList Estudiantes { get; set; }
        public SelectList Cursos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Calificacion = await _context.Calificaciones.FindAsync(id);

            if (Calificacion == null)
            {
                return NotFound();
            }

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

            _context.Attach(Calificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionExists(Calificacion.IdCalificacion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CalificacionExists(int id)
        {
            return _context.Calificaciones.Any(e => e.IdCalificacion == id);
        }
    }
}