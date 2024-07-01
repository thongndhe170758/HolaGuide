using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.DBRepository.Interfaces;
using System.Net.Mail;
using System.Net;

namespace HolaGuide.Pages.Authentication
{
    [Authorize]
    public class EmailVerificactionModel : PageModel
    {
        private readonly IUserRepository _userRepos;

        [BindProperty(SupportsGet = true, Name = "error")]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public string VerificationCode { get; set; }

        [BindProperty]
        public DateTime ExpirationTime { get; set; }

        public EmailVerificactionModel(IUserRepository userRepository)
        {
            _userRepos = userRepository;
        }

        public void OnGet()
        {
            var email = User.Claims.First(c => c.Type.Equals("Email")).Value;
            VerificationCode = new Random().Next(100000, 999999).ToString();
            SendVerificationEmail(email, VerificationCode);
            ExpirationTime = DateTime.Now.AddMinutes(1);
        }

        public IActionResult OnPost(string inputVerificationCode)
        {
            if(ExpirationTime < DateTime.Now)
            {
                ErrorMessage = "Mã xác nhận của bạn đã hết hạn";
                return Page();
            }
            if (!inputVerificationCode.Equals(VerificationCode))
            {
                ErrorMessage = "Mã xác nhận không đúng!";
                return Page();
            }
            var email = User.Claims.First(c => c.Type.Equals("Email")).Value;
            var result = _userRepos.UpdateActivation(new Models.SQLServer.User
            {
                Email = email,
                IsActivate = true
            });
            try
            {
                var resultNum = int.Parse(result);
                if(resultNum <= 0)
                {
                    ErrorMessage = "Update fail!";
                    return Page();
                }
                return RedirectToPage("/Home/UserHome");
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }

        private void SendVerificationEmail(string toAddress, string verificationCode)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("daohqhe170948@fpt.edu.vn", "HolaGuide"); // Replace with your email address
            mail.To.Add(toAddress);
            mail.Subject = "Account Verification";
            mail.Body = $"Your verification code is: {verificationCode}";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // Replace with your SMTP server
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Port = 587; // Replace with your SMTP port number
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("daohqhe170948@fpt.edu.vn", "kmzi obtc ckio reuz"); // Replace with your SMTP credentials
            smtpClient.EnableSsl = true; // Enable SSL if required

            smtpClient.Send(mail);
        }
    }
}
