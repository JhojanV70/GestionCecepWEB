using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionCecepWEB.Data;
using GestionCecepWEB.Models;

namespace GestionCecepWEB.Pages.Estudiantes
{
    public class IndexModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public IndexModel(GestionCecepContext context)
        {
            _context = context;
        }
        public IList<Estudiante> Estudiantes { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Estudiantes != null)
            {
                Estudiantes = await _context.Estudiantes.ToListAsync();
            }
        }
    }
}
