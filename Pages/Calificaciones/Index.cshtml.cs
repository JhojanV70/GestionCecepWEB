using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Calificaciones
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public IndexModel(GestionCecepContext context)
        {
            _context = context;
        }
        public IList<Calificacion> Calificaciones { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Calificaciones != null)
            {
                Calificaciones = await _context.Calificaciones.ToListAsync();
            }
        }
    }
}
