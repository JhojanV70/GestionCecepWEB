using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionCecepWEB.Data;
using GestionCecepWEB.Models;

namespace GestionCecepWEB.Pages.Estudiantes
{
    public class EditModel : PageModel
    {
        private readonly GestionCecepContext _context;

        public EditModel(GestionCecepContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Estudiante Estudiante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var Estudiante = await _context.Estudiantes.FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (Estudiante == null)
            {
                return NotFound();
            }
            this.Estudiante = Estudiante;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Estudiante.IdEstudiante))
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
            return (_context.Estudiantes?.Any(e => e.IdEstudiante == id)).GetValueOrDefault();
        }
    }
}
