using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Cursos
{
    public class EditModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public EditModel(GestionCecepContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Curso Curso { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var Curso = await _context.Cursos.FirstOrDefaultAsync(m => m.IdCurso == id);
            if (Curso == null)
            {
                return NotFound();
            }
            this.Curso = Curso;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Curso.IdCurso))
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

        private bool CategoryExists(int id)
        {
            return (_context.Cursos?.Any(e => e.IdCurso == id)).GetValueOrDefault();
        }
    }
}
