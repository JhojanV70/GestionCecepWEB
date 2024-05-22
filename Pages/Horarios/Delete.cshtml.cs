using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Horarios
{
    public class DeleteModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public DeleteModel(GestionCecepContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Horario Horario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var Horario = await _context.Horarios.FirstOrDefaultAsync(m => m.IdHorario == id);

            if (Horario == null)
            {
                return NotFound();
            }
            else
            {
                this.Horario = Horario;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }
            var Horario = await _context.Horarios.FindAsync(id);

            if (Horario != null)
            {
                this.Horario = Horario;
                _context.Horarios.Remove(Horario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
