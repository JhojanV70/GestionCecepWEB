using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Profesores
{
    public class EditModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public EditModel(GestionCecepContext context)
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
            this.Profesor = Profesor;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Profesor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Profesor.IdProfesor))
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
            return (_context.Profesores?.Any(e => e.IdProfesor == id)).GetValueOrDefault();
        }
    }
}
