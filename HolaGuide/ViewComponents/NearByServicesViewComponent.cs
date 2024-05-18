using Microsoft.AspNetCore.Mvc;
using Services.DBRepository.Interfaces;

namespace HolaGuide.ViewComponents
{
    public class NearByServicesViewComponent : ViewComponent
    {
        private readonly IServiceRepository _serviceRepos;
        private readonly ICategoryRepository _categoryRepos;

        public NearByServicesViewComponent(IServiceRepository serviceRepos, ICategoryRepository categoryRepos)
        {
            _serviceRepos = serviceRepos;
            _categoryRepos = categoryRepos;
        }

        public IViewComponentResult Invoke(string categoryName)
        {
            var category = _categoryRepos.Get(c => c.Name == categoryName);
            if (category == null) return View(null);

            var result = _serviceRepos.Gets(s => s.CategoryId == category.Id);
            return View(result);
        }
    }
}
