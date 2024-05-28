using Microsoft.AspNetCore.Mvc;
using Services.DBRepository.Interfaces;

namespace HolaGuide.ViewComponents
{
    public class NewestServicesViewComponent : ViewComponent
    {
        private readonly IServiceRepository _serviceRepos;
        private readonly ICategoryRepository _categoryRepos;

        public NewestServicesViewComponent(IServiceRepository serviceRepos, ICategoryRepository categoryRepos)
        {
            _serviceRepos = serviceRepos;
            _categoryRepos = categoryRepos;
        }

        public IViewComponentResult Invoke(string categoryName, string searchKey)
        {
            var category = _categoryRepos.Get(c => c.Name == categoryName);
            if (category == null) return View(null);

            var result = _serviceRepos.Gets(s => s.CategoryId == category.Id && s.Name.Contains(searchKey)).OrderByDescending(s => s.Id).ToList();
            return View(result);
        }
    }
}
