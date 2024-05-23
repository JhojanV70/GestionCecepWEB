using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GestionCecepWEB.Pages.Profesores
{
    public class IndexModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public IndexModel(GestionCecepContext context)
        {
            _context = context;
        }
        public IList<Profesor> Profesores { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Profesores != null)
            {
                Profesores = await _context.Profesores.ToListAsync();
            }
        }
    }
}
