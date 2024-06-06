using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.SQLServer;
using Services.DBRepository.Interfaces;

namespace HolaGuide.Pages.Service
{
    public class DetailModel : PageModel
    {
        private readonly IServiceRepository _serviceRepos;
        private readonly IFeedbackRepository _feedbackRepo;

        public Models.SQLServer.Service Service { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Models.SQLServer.Service> RelatedServices { get; set; }

        public DetailModel(IServiceRepository serviceRepos, IFeedbackRepository feedbackRepo)
        {
            _serviceRepos = serviceRepos;
            _feedbackRepo = feedbackRepo;
        }

        public IActionResult OnGet(int serviceId)
        {
            var service = _serviceRepos.GetDetailedService(serviceId);
            if (service == null) return RedirectToPage("/Static/NotFound");
            Service = service;

            Feedbacks = _feedbackRepo.Gets(f => f.ServiceId == serviceId);

            RelatedServices = _serviceRepos.Gets(s => s.Id != serviceId && s.CategoryId == service.CategoryId).OrderByDescending(s => s.Id).Take(4).ToList();
            return Page();
        }
    }
}
