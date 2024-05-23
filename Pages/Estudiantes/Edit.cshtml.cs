using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionCecepWEB.Pages.Estudiantes
{
    public class EditModel : PageModel
    {
        private readonly GestionCecepContext _context;

        public EditModel(GestionCecepContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Cursos { get; set; }

        [BindProperty]
        public Estudiante Estudiante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Estudiante = await _context.Estudiantes.FindAsync(id);

            if (Estudiante == null)
            {
                return NotFound();
            }

            Cursos = await _context.Cursos.Select(c =>
                new SelectListItem
                {
                    Value = c.IdCurso.ToString(),
                    Text = c.NombreCurso,
                    Selected = (c.IdCurso == Estudiante.IdCurso)
                }).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Cursos = await _context.Cursos.Select(c =>
                    new SelectListItem
                    {
                        Value = c.IdCurso.ToString(),
                        Text = c.NombreCurso,
                        Selected = (c.IdCurso == Estudiante.IdCurso)
                    }).ToListAsync();
                return Page();
            }

            var Curso = await _context.Cursos.FindAsync(Estudiante.IdCurso);

            if (Curso == null)
            {
                ModelState.AddModelError("", "Invalid category selected.");
                Cursos = await _context.Cursos.Select(c =>
                    new SelectListItem
                    {
                        Value = c.IdCurso.ToString(),
                        Text = c.NombreCurso,
                        Selected = (c.IdCurso == Estudiante.IdCurso)
                    }).ToListAsync();
                return Page();
            }

            _context.Attach(Estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Estudiante.IdCurso))
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

        private bool ProductExists(int id)
        {
            return _context.Estudiantes.Any(p => p.IdEstudiante == id);
        }
    }
}
