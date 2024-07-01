using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Models.SQLServer;
using Services.DBRepository.Interfaces;
using Services.Global;

namespace HolaGuide.Pages.Service
{
    public class DetailModel : PageModel
    {
        private readonly IServiceRepository _serviceRepos;
        private readonly IFeedbackRepository _feedbackRepo;

        public Models.SQLServer.Service Service { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public Feedback? MyFeedback { get; set; }
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

            var userID = User.Identity.IsAuthenticated ? int.Parse(User.Claims.First(c => c.Type == "ID").Value) : 0;
            if(userID != 0)
            {
                MyFeedback = _feedbackRepo.Get(f => f.ServiceId == serviceId && f.UserId == userID);
            }
            Feedbacks = _feedbackRepo.Gets(f => f.ServiceId == serviceId && f.UserId != userID).OrderByDescending(f => f.PostDate).ToList();

            RelatedServices = _serviceRepos.Gets(s => s.Id != serviceId && s.CategoryId == service.CategoryId).OrderByDescending(s => s.Id).Take(4).ToList();
            return Page();
        }

        public IActionResult OnPostSendFeedback()
        {
            string content = Request.Form["content"];
            int userId = int.Parse(Request.Form["userId"]);
            int serviceId = int.Parse(Request.Form["serviceId"]);

            var feedback = new Feedback { UserId = userId, ServiceId = serviceId, Content = content, PostDate = DateTime.Now };
            var result = _feedbackRepo.Create(feedback);
            if(result.DataCount != 0)
            {
                var postDate = GlobalService.FromDateToTime(feedback.PostDate);
                return new JsonResult(new { message = result.Message, status = 200, data = result.Data, postdate = postDate });
            }
            else
            {
                return new JsonResult(new { message = result.Message, status = 500 });
            }      
        }

        public IActionResult OnPostRemoveFeedback(int feedbackId, int serviceId)
        {
            var feedback = _feedbackRepo.Get(f => f.Id == feedbackId);
            if(feedback == null)
            {
                return RedirectToPage("/Service/Detail", new { serviceId = serviceId });
            }
            var result = _feedbackRepo.Remove(feedback);
            return RedirectToPage("/Service/Detail", new { serviceId = serviceId });
        }
    }
}
