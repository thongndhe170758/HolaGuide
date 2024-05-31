using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Input_Models;
using Services.DBRepository.Interfaces;
using Services.Global;
using System.Collections;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HolaGuide.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        [BindProperty(SupportsGet = true, Name = "error")]
        public string ErrorMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogin(string returnUrl,UserCredentials credentials)
        {
            var user = await _userRepository.Get(s => s.Email == credentials.Email);
            if (user == null)
            {
                return RedirectToPage(new { error = "No Email Found!" });
            }
            if (!GlobalService.VerifyPassword(credentials.Password, Encoding.Unicode.GetString(user.Password)))
            {
                return RedirectToPage(new { error = returnUrl ?? "asdasd" });
            }
            var claims = new List<Claim>
            {
                new Claim("ID", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("Role",user.Role.ToString()),
                new Claim("Code", user.Code),
                new Claim("Name", user.Name)
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var principle = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", principle);

            string alternativeUrl = $"/Home/{(user.Role != "admin" ? "UserHome" : "AdminHome")}";
            return RedirectToPage(string.IsNullOrEmpty(returnUrl) ? alternativeUrl : returnUrl);
        }

    }
}
