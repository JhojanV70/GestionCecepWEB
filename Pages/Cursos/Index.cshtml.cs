using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public IndexModel(GestionCecepContext context)
        {
            _context = context;
        }
        public IList<Curso> Cursos { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Cursos != null)
            {
                Cursos = await _context.Cursos.ToListAsync();
            }
        }
    }
}
