using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Calificaciones
{
    public class DeleteModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public DeleteModel(GestionCecepContext context)
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
            else
            {
                this.Calificacion = Calificacion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Calificaciones == null)
            {
                return NotFound();
            }
            var Calificacion = await _context.Calificaciones.FindAsync(id);

            if (Calificacion != null)
            {
                this.Calificacion = Calificacion;
                _context.Calificaciones.Remove(Calificacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
