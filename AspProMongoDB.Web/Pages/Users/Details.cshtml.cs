using AspProMongoDB.Web.Entities;
using AspProMongoDB.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspProMongoDB.Web.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly IUserService _userService;

        public DetailsModel(IUserService userService)
        {
            _userService = userService;
        }

        public User User { get; set; }

        public IActionResult OnGet(Guid id)
        {

            User = _userService.GetById(id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
