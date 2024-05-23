using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Cursos
{
    public class DeleteModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public DeleteModel(GestionCecepContext context)
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
            else
            {
                this.Curso = Curso;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }
            var Curso = await _context.Cursos.FindAsync(id);

            if (Curso != null)
            {
                this.Curso = Curso;
                _context.Cursos.Remove(Curso);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
