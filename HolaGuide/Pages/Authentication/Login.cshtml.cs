using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Input_Models;
using Services.DBRepository.Interfaces;
using System.Security.Claims;

namespace HolaGuide.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        [BindProperty(SupportsGet = true, Name = "error")]
        public string ErrorMessage { get; set; }

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogin(UserCredentials credentials)
        {
            var user = await _userRepository.Get(s => s.Email == credentials.Email);
            if (user == null)
            {
                return RedirectToPage(new { error = "No Email Found!" });
            }
            if (!user.Password.Equals(credentials.Password))
            {
                return RedirectToPage(new { error = "Incorrect Password!" });
            }
            var claims = new List<Claim>
            {
                new Claim("ID", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("Role",user.Role.ToString())
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var principle = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", principle);

            return RedirectToPage($"/Home/{(user.Role != 2 ? "UserHome" : "AdminHome")}");
        }
    }
}
