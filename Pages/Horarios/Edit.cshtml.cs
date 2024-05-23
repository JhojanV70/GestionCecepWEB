using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public Horario Horario { get; set; }

        public SelectList Cursos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Horario = await _context.Horarios.FindAsync(id);

            if (Horario == null)
            {
                return NotFound();
            }

            Cursos = new SelectList(_context.Cursos, "IdCurso", "NombreCurso", Horario.IdCurso);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Cursos = new SelectList(_context.Cursos, "IdCurso", "NombreCurso", Horario.IdCurso);
                return Page();
            }

            _context.Attach(Horario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioExists(Horario.IdHorario))
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

        private bool HorarioExists(int id)
        {
            return _context.Horarios.Any(e => e.IdHorario == id);
        }
    }
}