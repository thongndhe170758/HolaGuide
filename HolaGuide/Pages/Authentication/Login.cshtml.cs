using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Models.Input_Models;
using Models.SQLServer;
using Services.DBRepository.Interfaces;
using Services.Global;
using System;
using System.Collections;
using System.Net;
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
        public string Type { get; set; } = "login";

        [BindProperty]
        public UserCredentials LoginCredentials { get; set; } = new UserCredentials();

        [BindProperty]
        public AccountRegister RegisterCredentials { get; set; } = new AccountRegister();

        public LoginModel(IUserRepository userRepository, IUserSubscriptionRepository userSubscriptionRepository)
        {
            _userRepository = userRepository;
            _userSubscriptionRepository = userSubscriptionRepository;
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(Type) || (!Type.Equals("login") && !Type.Equals("signup"))) Type = "login";
        }

        public async Task<IActionResult> OnPostLogin()
        {
            var user = _userRepository.Get(s => s.Email == LoginCredentials.Email);
            if (user == null)
            {
                ErrorMessage = "Email không tồn tại!";
                return Page();
            }
            if (!GlobalService.VerifyPassword(LoginCredentials.Password, Encoding.Unicode.GetString(user.Password)))
            {
                ErrorMessage = "Mật khẩu không chính xác!";
                return Page();
            }

            //check isSubscripted
            var isSubscripted = _userSubscriptionRepository.Gets(u => u.UserId == user.Id && u.IsPurchased).Any(u => u.Subscription.Price == 0);
            await GenerateToken(user, isSubscripted, LoginCredentials.IsRemember);
            
            if(user.IsActivate == null)
            {
                return RedirectToPage("/Authentication/EmailVerification");
            }
            if(user.IsActivate == false)
            {
                ErrorMessage = "Tài khoản của bạn đã bị vô hiệu hóa!";
                return Page();
            }

            string alternativeUrl = $"/Home/{(user.Role != "admin" ? "UserHome" : "AdminHome")}";
            if (string.IsNullOrEmpty(ReturnUrl)) return RedirectToPage(alternativeUrl);

            var split= ReturnUrl.Split('?');
            var pageName = split[0];

            if(split.Length > 1)
            {
                Dictionary<string, StringValues> queryParams = QueryHelpers.ParseQuery(split[1]);
                var routeValues = new RouteValueDictionary();
                foreach (var kvp in queryParams)
                {
                    routeValues.Add(kvp.Key, kvp.Value.FirstOrDefault());
                }
                return RedirectToPage(pageName, routeValues);
            }
            return RedirectToPage(pageName);
        }

        public async Task<IActionResult> OnPostSignUp()
        {
            if(!Regex.IsMatch(RegisterCredentials.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                Type = "signup";
                ErrorMessage = "Email không hợp lệ!";
                return Page();
            }
            var checkuser = _userRepository.Get(s => s.Email == RegisterCredentials.Email);
            if(checkuser != null)
            {
                Type = "signup";
                ErrorMessage = "Email này đã được sử dụng!";
                return Page();
            }
            if (!Regex.IsMatch(RegisterCredentials.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
            {
                Type = "signup";
                ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự bao gồm một chữ in hoa và một chữ in thường!";
                return Page();
            }
            if (!RegisterCredentials.ConfirmPassword.Equals(RegisterCredentials.Password))
            {
                Type = "signup";
                ErrorMessage = "Mật khẩu không khớp!";
                return Page();
            }
            var user = new User
            {
                Email = RegisterCredentials.Email,
                Password = Encoding.Unicode.GetBytes(GlobalService.HashPassword(RegisterCredentials.Password)),
                Name = RegisterCredentials.FullName,
                Role = "user",
            };
            _userRepository.Create(user);
            await GenerateToken(user, false, false);
            return RedirectToPage("/Authentication/EmailVerification");
        }

        private async Task GenerateToken(User user, bool isSupcripted, bool isRemember)
        {
            var claims = new List<Claim>
            {
                new Claim("ID", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("Role",user.Role.ToString()),
                new Claim("Code", user.Code),
                new Claim("Name", user.Name),
                new Claim("IsSubscript", (!isSupcripted).ToString())
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = isRemember,
                ExpiresUtc = isRemember ? DateTime.UtcNow.AddDays(10) : DateTime.UtcNow.AddMinutes(10)
            };
            var principle = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", principle, authenticationProperties);
        }
    }
}
