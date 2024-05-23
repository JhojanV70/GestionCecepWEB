using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace GestionCecepWEB.Pages.Profesores
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
        public Profesor Profesor { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Profesores == null || Profesor == null)
            {
                return Page();
            }

            _context.Profesores.Add(Profesor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
