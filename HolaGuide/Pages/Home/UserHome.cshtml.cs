using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.SQLServer;
using Services.DBRepository.Interfaces;

namespace HolaGuide.Pages.Home
{
    public class UserHomeModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepos;
        public List<Category> Categories { get; set; }

        [BindProperty(SupportsGet = true, Name = "selectedCategory")]
        public string? SelectedCategory { get; set; }

        public UserHomeModel(ICategoryRepository categoryRepos)
        {
            _categoryRepos = categoryRepos;
        }

        public void OnGet()
        {
            Categories = _categoryRepos.Gets(_ => true);
        }
    }
}
