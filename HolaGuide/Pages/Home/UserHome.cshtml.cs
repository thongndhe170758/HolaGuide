using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.SQLServer;
using Services.DBRepository.Interfaces;

namespace HolaGuide.Pages.Home
{
    public class UserHomeModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepos;

        public List<Category> Categories { get; set; } = new List<Category>();

        [BindProperty(SupportsGet = true, Name = "category")]
        public string? SelectedCategory { get; set; }

        [BindProperty(SupportsGet = true, Name = "filter")]
        public string? FilterString { get; set; }

        [BindProperty(Name = "query")]
        public string SearchKey { get; set; } = string.Empty;

        public UserHomeModel(ICategoryRepository categoryRepos)
        {
            _categoryRepos = categoryRepos;
        }

        public void OnGet()
        {
            SetUpPage();
        }

        public void OnPostSaveService()
        {
            SetUpPage();
        }

        public void OnPost()
        {
            SetUpPage();
        }

        private void SetUpPage()
        {
            Categories = _categoryRepos.Gets(_ => true);
            if (SelectedCategory == null) SelectedCategory = Categories[0].Name;

            var category = _categoryRepos.Get(c => c.Name == SelectedCategory);
            if (category == null) SelectedCategory = Categories[0].Name;

            if (FilterString == null)
            {
                FilterString = "Mới Nhất";
            }
        }
    }
}

