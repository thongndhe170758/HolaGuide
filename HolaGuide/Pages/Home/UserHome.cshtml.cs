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

        [BindProperty(SupportsGet = true, Name = "query")]
        public string? SearchKey { get; set; }

        [BindProperty(SupportsGet = true, Name = "pagenumber")]
        public int? PageNumber { get; set; }

        public string? Message { get; set; }

        [BindProperty(SupportsGet = true, Name = "longitude")]
        public double? Longitude { get; set; }

        [BindProperty(SupportsGet = true, Name = "latitude")]
        public double? Latitude { get; set; }

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
            Message = TempData["message"] as string;
            TempData.Remove("message");

            Categories = _categoryRepos.Gets(_ => true);
            if (SelectedCategory == null) SelectedCategory = Categories[0].Name;

            var category = _categoryRepos.Get(c => c.Name == SelectedCategory);
            if (category == null) SelectedCategory = Categories[0].Name;

            if (string.IsNullOrEmpty(FilterString))
            {
                FilterString = "Mới nhất";
            }

            if (SearchKey == null) SearchKey = string.Empty;
            if (PageNumber == null) PageNumber = 1;
        }
    }
}

