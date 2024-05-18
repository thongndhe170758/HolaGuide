using Models.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Interfaces
{
    public interface IServiceRepository
    {
        public List<Service> Gets(Expression<Func<Service, bool>> predicate);
        public Service? Get(Expression<Func<Service, bool>> predicate);
        public List<Service> GetSavedServices(int UserID, int categoryID);
        public Service? GetDetailedService(int serviceID);
    }
}
