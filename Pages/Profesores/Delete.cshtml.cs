using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Profesores
{
    public class DeleteModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public DeleteModel(GestionCecepContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profesor Profesor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var Profesor = await _context.Profesores.FirstOrDefaultAsync(m => m.IdProfesor == id);

            if (Profesor == null)
            {
                return NotFound();
            }
            else
            {
                this.Profesor = Profesor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }
            var Profesor = await _context.Profesores.FindAsync(id);

            if (Profesor != null)
            {
                this.Profesor = Profesor;
                _context.Profesores.Remove(Profesor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
