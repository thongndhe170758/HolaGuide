using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.SQLServer;
using Services.DBRepository.Interfaces;

namespace HolaGuide.Pages.Home
{
    public class UserHomeModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepos;
        private readonly IServiceRepository _serviceRepos;

        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Service> Services { get; set; } = new List<Service>();

        [BindProperty(SupportsGet = true, Name = "category")]
        public string? SelectedCategory { get; set; }

        public UserHomeModel(ICategoryRepository categoryRepos, IServiceRepository serviceRepos)
        {
            _categoryRepos = categoryRepos;
            _serviceRepos = serviceRepos;
        }

        public void OnGet()
        {
            Categories = _categoryRepos.Gets(_ => true);
            if(SelectedCategory == null)
            {
                SelectedCategory = Categories[0].Name;
            }

            var category = Categories.Find(c => c.Name.Equals(SelectedCategory));
            if(category != null)
            {
                Services = _serviceRepos.Gets(s => s.CategoryId == category.Id);
            }
        }
    }
}

