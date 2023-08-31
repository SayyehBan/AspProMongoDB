using AspProMongoDB.Web.Entities;
using AspProMongoDB.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspProMongoDB.Web.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _userService.GetAll();
        }
    }
}
