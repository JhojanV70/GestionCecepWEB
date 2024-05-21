using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Users
{
    public class DeleteModel : PageModel
	{
		private readonly GestionCecepContext cecepContext;

		public DeleteModel(GestionCecepContext context)
		{
			cecepContext = context;
		}

		[BindProperty]

		public User User { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || cecepContext.Users == null)
			{
				return NotFound();
			}

			var user = await cecepContext.Users.FirstOrDefaultAsync(m => m.Id == id);

			if (user == null)
			{
				return NotFound();
			}
			else
			{
				User = user;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || cecepContext.Users == null)
			{
				return NotFound();
			}
			var users = await cecepContext.Users.FindAsync(id);

			if (users != null)
			{
				User = users;
					cecepContext.Users.Remove(User);
				await cecepContext.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}