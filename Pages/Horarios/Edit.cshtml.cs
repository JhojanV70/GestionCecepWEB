using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Horarios
{
    public class EditModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public EditModel(GestionCecepContext context)
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
            this.Horario = Horario;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Horario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Horario.IdHorario))
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
            return (_context.Horarios?.Any(e => e.IdHorario == id)).GetValueOrDefault();
        }
    }
}
