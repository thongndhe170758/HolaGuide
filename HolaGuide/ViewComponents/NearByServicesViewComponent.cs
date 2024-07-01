using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Services.DBRepository.Interfaces;
using Services.Global;

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

        public IViewComponentResult Invoke(string categoryName, string searchKey, string filter, int pageNum, double longitude, double latitude)
        {
            var category = _categoryRepos.Get(c => c.Name == categoryName);
            if (category == null) return View(null);

            var result = _serviceRepos.Gets(s => s.CategoryId == category.Id && s.Name.Contains(searchKey))
                                       .OrderBy(s => GlobalService.CalculateDistance(latitude,longitude,s.Location.Latitude,s.Location.Longtitude))
                                       .Select(s => new {
                                           Name = s.Name,
                                           Id = s.Id,
                                           Location = s.Location,
                                           Images = s.Images.ToList(),
                                           Distance = GlobalService.CalculateDistance(latitude, longitude, s.Location.Latitude, s.Location.Longtitude)
                                        })
                                       .ToList();
            var totalResult = result.Count;

            //Phân trang
            int lastPage = (int)Math.Ceiling(result.Count / 12.0);
            if (pageNum == 0 || pageNum > lastPage) pageNum = 1;

            result = result.Skip(12 * (pageNum - 1)).Take(12).ToList();
            return View(
                new
                {
                    Data = result,
                    Search = searchKey,
                    Category = categoryName,
                    Filter = filter,
                    Page = pageNum,
                    LastPage = lastPage,
                    TotalResult = totalResult,
                    Longitude = longitude,
                    Latitude = latitude
                });
        }
    }
}
