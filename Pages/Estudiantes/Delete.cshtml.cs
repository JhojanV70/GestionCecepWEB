using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionCecepWEB.Data;
using GestionCecepWEB.Models;

namespace GestionCecepWEB.Pages.Estudiantes
{
    public class DeleteModel : PageModel
    {
        private readonly GestionCecepContext _context;

        public DeleteModel(GestionCecepContext context)
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
            else
            {
                this.Estudiante = Estudiante;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }
            var Estudiante = await _context.Estudiantes.FindAsync(id);

            if (Estudiante != null)
            {
                this.Estudiante = Estudiante;
                _context.Estudiantes.Remove(Estudiante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}