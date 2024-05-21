using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionCecepWEB.Data;
using GestionCecepWEB.Models;

namespace GestionCecepWEB.Pages.Users
{
	[Authorize]
    public class IndexModel : PageModel
    {
		private readonly GestionCecepContext cecepContext;

		public IndexModel(GestionCecepContext context)
		{
			cecepContext = context;
		}

		public IList<User> User { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (cecepContext.Users != null)
			{
				User = await cecepContext.Users.ToListAsync();
			}
		}
	}
}