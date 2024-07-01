using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.SQLServer;
using Services.DBRepository.Interfaces;
using Services.Global;

namespace HolaGuide.Pages.Home
{
    [Authorize(Policy = "admin")]
    public class AdminHomeModel : PageModel
    {
        private readonly IServiceRepository _serviceRepos;
        private readonly IImageRepository _imageRepos;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public string Message { get; set; }

        public AdminHomeModel(IServiceRepository serviceRepos, IWebHostEnvironment hostingEnvironment, IImageRepository imageRepos)
        {
            _serviceRepos = serviceRepos;
            _hostingEnvironment = hostingEnvironment;
            _imageRepos = imageRepos;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Models.SQLServer.Service model, double latitude, double longitude, string description)
        {
            model.Location = new Models.SQLServer.Location() { Latitude = latitude, Longtitude = longitude, Description = description };
            var result = _serviceRepos.Create(model);
            if (result.DataCount == 0)
            {
                return RedirectToPage("/Home/AdminHome", new { Message = result.Message });
            }

            var files = Request.Form.Files;
            var category = GlobalService.GetEngCategoryName(result.Data.CategoryId);

            var serviceFolderName = $"service_{result.Data.Id}";
            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "services", category, serviceFolderName);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            int fileCount = 1;
            var images = new List<Models.SQLServer.Image>();

            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                {
                    continue;
                }

                var fileName = $"img_{fileCount}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                //save to database
                images.Add(new Image
                {
                    ServiceId = result.Data.Id,
                    Path = "/" + Path.Combine("images", "services", category, serviceFolderName, fileName).Replace('\\','/'),
                });

                fileCount++;
            }
            _imageRepos.CreateMany(images);

            return RedirectToPage("/Home/AdminHome", new { Message = result.Message });
        }
    }
}
