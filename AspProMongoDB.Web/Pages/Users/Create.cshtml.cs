using AspProMongoDB.Web.Entities;
using AspProMongoDB.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspProMongoDB.Web.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.Insert(User);

            return RedirectToPage("./Index");
        }
    }
}
