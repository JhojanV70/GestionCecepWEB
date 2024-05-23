using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Horarios
{
    public class IndexModel : PageModel
    {
        private readonly GestionCecepContext _context;
        public IndexModel(GestionCecepContext context)
        {
            _context = context;
        }
        public IList<Horario> Horarios { get; set; } = default!;
        public async Task OnGetAsync()
        {
            
            if (_context.Horarios != null)
            {
                Horarios = await _context.Horarios.ToListAsync();               
                
            }
           
        }
    }
}