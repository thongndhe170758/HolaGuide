using Infrastructure.SQLServer;
using Models.Output_Models;
using Models.SQLServer;
using Services.DBRepository.Interfaces;
using Services.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Implements
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(HolaGuide_TestContext HolaGuide_TestContext) : base(HolaGuide_TestContext) { }

        public EntityOperationResponse<Image> CreateMany(ICollection<Image> images)
        {
            try
            {
                DbContext.Images.AddRange(images);
                var result = DbContext.SaveChanges();
                if (result <= 0) return new EntityOperationResponse<Image> { Message = "Lỗi post feedback!", DataCount = 0 };
                return new EntityOperationResponse<Image> { Message = "success", DataCount = result };
            }
            catch(Exception ex)
            {
                return new EntityOperationResponse<Image>
                {
                    Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message,
                    DataCount = 0,
                };
            }
        }
    }
}
