using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultiUserBloggingPlatform.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly DataLayer dataLayer;

        public RegisterModel(DataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string Username, string Password, string Email) //upon form submission
        {
            dataLayer.CreateUser(Username, Password, Email);
            return RedirectToPage("/Account/Login"); //redirect to login page after successful registration
        }
    }
}
