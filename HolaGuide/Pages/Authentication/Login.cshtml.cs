using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Input_Models;
using Models.SQLServer;
using Services.DBRepository.Interfaces;
using Services.Global;
using System.Collections;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace HolaGuide.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;

        [BindProperty(SupportsGet = true, Name = "error")]
        public string ErrorMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        [BindProperty(SupportsGet = true, Name = "authType")]
        public string? Type { get; set; }

        public LoginModel(IUserRepository userRepository, IUserSubscriptionRepository userSubscriptionRepository)
        {
            _userRepository = userRepository;
            _userSubscriptionRepository = userSubscriptionRepository;
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(Type) || (!Type.Equals("login") && !Type.Equals("signup"))) Type = "login";
        }

        public async Task<IActionResult> OnPostLogin(string returnUrl,UserCredentials credentials)
        {
            var user = _userRepository.Get(s => s.Email == credentials.Email);
            if (user == null)
            {
                return RedirectToPage(new { error = "Email không tồn tại!" });
            }
            if (!GlobalService.VerifyPassword(credentials.Password, Encoding.Unicode.GetString(user.Password)))
            {
                return RedirectToPage(new { error = "Mật khẩu không chính xác!" });
            }

            //check isSubscripted
            var isSubscripted = _userSubscriptionRepository.Gets(u => u.UserId == user.Id && u.IsPurchased).Any(u => u.Subscription.Price == 0);

            var claims = new List<Claim>
            {
                new Claim("ID", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("Role",user.Role.ToString()),
                new Claim("Code", user.Code),
                new Claim("Name", user.Name),
                new Claim("IsSubscript", (!isSubscripted).ToString())
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = credentials.IsRemember, 
                ExpiresUtc = credentials.IsRemember ? DateTime.UtcNow.AddDays(10) : DateTime.UtcNow.AddMinutes(10)
            };
            var principle = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", principle, authenticationProperties);

            string alternativeUrl = $"/Home/{(user.Role != "admin" ? "UserHome" : "AdminHome")}";
            return RedirectToPage(string.IsNullOrEmpty(returnUrl) ? alternativeUrl : returnUrl);
        }

        public IActionResult OnPostSignUp(AccountRegister input)
        {
            if(!Regex.IsMatch(input.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return RedirectToPage("/Authentication/Login", new { authType = "signup", error = "Email không hợp lệ!" });
            }
            if (!Regex.IsMatch(input.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
            {
                return RedirectToPage("/Authentication/Login", new { authType = "signup", error = "Mật khẩu phải có ít nhất 8 ký tự bao gồm cả chữ in hoa và một chữ in thường!" });
            }
            if (!input.ConfirmPassword.Equals(input.Password))
            {
                return RedirectToPage("/Authentication/Login", new
                {
                    authType = "signup",
                    error = "Mật khẩu không khớp!"
                });
            }
            var user = new User
            {
                Email = input.Email,
                Password = Encoding.Unicode.GetBytes(GlobalService.HashPassword(input.Password)),
                Name = input.FullName,
                Role = "user",
                IsActivate = false,
            };
            _userRepository.Create(user);
            return RedirectToPage("/Authentication/Login");
        }
    }
}
