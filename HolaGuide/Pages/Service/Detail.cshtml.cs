using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.SQLServer;
using Services.DBRepository.Interfaces;

namespace HolaGuide.Pages.Service
{
    public class DetailModel : PageModel
    {
        private readonly IServiceRepository _serviceRepos;

        public Models.SQLServer.Service Service { get; set; }

        public DetailModel(IServiceRepository serviceRepos)
        {
            _serviceRepos = serviceRepos;
        }

        public IActionResult OnGet(int serviceId)
        {
            var service = _serviceRepos.GetDetailedService(serviceId);
            if (service == null) return RedirectToPage("/Static/NotFound");
            Service = service;
            return Page();
        }
    }
}
