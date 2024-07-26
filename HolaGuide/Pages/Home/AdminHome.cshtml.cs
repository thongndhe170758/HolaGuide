using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.SQLServer;
using Services.DBRepository.Interfaces;
using Services.Global;

namespace HolaGuide.Pages.Home
{
    [Authorize(Policy = "admin")]
    public class AdminHomeModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "message")]
        public string Message { get; set; }

        public void OnGet()
        {
        }

    }
}
