using Models.Output_Models;
using Models.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Interfaces
{
    public interface IImageRepository
    {
        public EntityOperationResponse<Image> CreateMany(ICollection<Image> images);
    }
}
