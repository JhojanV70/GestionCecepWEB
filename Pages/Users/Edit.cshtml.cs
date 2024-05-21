using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionCecepWEB.Pages.Users
{
    public class EditModel : PageModel
	{
		private readonly GestionCecepContext cecepContext;

		public EditModel(GestionCecepContext context)
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
			User = user;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			cecepContext.Attach(User).State = EntityState.Modified;

			try
			{
				await cecepContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!UserExists(User.Id))
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

		private bool UserExists(int id)
		{
			return (cecepContext.Users?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}