using Microsoft.AspNetCore.Mvc;
using Services.DBRepository.Implements;
using Services.DBRepository.Interfaces;

namespace HolaGuide.ViewComponents.CategoryDropdown
{
    public class CategoryDropdownViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepos;

        public CategoryDropdownViewComponent(ICategoryRepository categoryRepos)
        {
            _categoryRepos = categoryRepos;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepos.Gets(_ => true);
            return View(categories);
        }
    }
}
