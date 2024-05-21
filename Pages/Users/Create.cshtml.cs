using GestionCecepWEB.Data;
using GestionCecepWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionCecepWEB.Pages.Users
{
    public class CreateModel : PageModel
	{
		private readonly GestionCecepContext cecepContext;

		public CreateModel(GestionCecepContext context)
		{
			cecepContext = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]

		public User User { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || cecepContext.Users == null || User == null)
			{
				return Page();
			}

			cecepContext.Users.Add(User);
			await	cecepContext.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}