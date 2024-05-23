using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionCecepWEB.Pages.Calificaciones
{
    public class CreateModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public CreateModel(GestionCecepContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Calificacion Calificacion { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Calificaciones == null || Calificacion == null)
            {
                return Page();
            }

            _context.Calificaciones.Add(Calificacion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
