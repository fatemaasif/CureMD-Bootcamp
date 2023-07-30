using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultiUserBloggingPlatform.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly DataLayer dataLayer;
        public LoginModel(DataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }
        public void OnGet()
        {
        }
        //public IActionResult OnPost(string username, string password) 
        //{
        //    dataLayer.GetUser()
        //}
    }
}
