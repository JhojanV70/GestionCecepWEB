using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public Calificacion Calificacion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Calificaciones == null)
            {
                return NotFound();
            }

            var Calificacion = await _context.Calificaciones.FirstOrDefaultAsync(m => m.IdCalificacion == id);
            if (Calificacion == null)
            {
                return NotFound();
            }
            this.Calificacion = Calificacion;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Calificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Calificacion.IdCalificacion))
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
            return (_context.Calificaciones?.Any(e => e.IdCalificacion == id)).GetValueOrDefault();
        }
    }
}

