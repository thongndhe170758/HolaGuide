using Infrastructure.SQLServer;
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
            return DbContext.Services.Where(predicate).ToList();
        }
    }
}
