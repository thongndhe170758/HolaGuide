using Infrastructure.SQLServer;
using Microsoft.EntityFrameworkCore;
using Models.Output_Models;
using Models.SQLServer;
using Services.DBRepository.Interfaces;
using Services.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Implements
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(HolaGuide_TestContext HolaGuide_TestContext) : base(HolaGuide_TestContext) { }
        public Service? Get(Expression<Func<Service, bool>> predicate)
        {
            return DbContext.Services.FirstOrDefault(predicate);
        }

        public List<Service> Gets(Expression<Func<Service, bool>> predicate)
        {
            return DbContext.Services.Where(predicate).Include(s => s.Category).Include(s => s.Images).Include(s => s.Location).ToList();
        }

        public List<Service> GetSavedServices(int UserID, int categoryID)
        {
            return (from ss in DbContext.SaveServices.AsNoTracking()
                    where ss.UserId  == UserID
                    join s in DbContext.Services.AsNoTracking() on ss.ServiceId equals s.Id
                    join c in DbContext.Categories.AsNoTracking() on s.CategoryId equals c.Id
                    select s).ToList();
        }

        public Service? GetDetailedService(int serviceID)
        {
            return DbContext.Services.Where(s => s.Id == serviceID).Include(s => s.Images).Include(s => s.Location).FirstOrDefault();
        }

        public EntityOperationResponse<Service> Create(Service service)
        {
            try
            {
                DbContext.Services.Add(service);
                var result = DbContext.SaveChanges();
                if(result <= 0)
                {
                    return new EntityOperationResponse<Service> { DataCount = 0, Message = "Create service fail!" };
                }
                return new EntityOperationResponse<Service> { Message = "success", DataCount = result, Data = service };
            }
            catch(Exception ex)
            {
                return new EntityOperationResponse<Service> { Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message, DataCount = 0 };
            }
        }
    }
}
