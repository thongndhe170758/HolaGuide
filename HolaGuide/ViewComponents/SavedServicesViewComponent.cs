using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.SQLServer;
using Services.DBRepository.Interfaces;

namespace HolaGuide.ViewComponents
{
    public class SavedServicesViewComponent : ViewComponent
    {
        private readonly IServiceRepository _serviceRepos;
        private readonly ICategoryRepository _categoryRepos;

        public SavedServicesViewComponent(IServiceRepository serviceRepos, ICategoryRepository categoryRepos)
        {
            _serviceRepos = serviceRepos;
            _categoryRepos = categoryRepos;
        }

        public IViewComponentResult Invoke(string categoryName)
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                ViewBag.IsAuthenticated = false;
                return View(new List<Service>());
            }

            var category = _categoryRepos.Get(c => c.Name == categoryName);
            if (category == null) return View(null);

            var userID = UserClaimsPrincipal.Claims.First(c => c.Type == "ID").Value;
            var services = _serviceRepos.GetSavedServices(Int32.Parse(userID), category.Id);
            ViewBag.IsAuthenticated = true;
            return View(services);
        }
    }
}
