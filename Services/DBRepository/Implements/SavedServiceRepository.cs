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
    public class SavedServiceRepository : BaseRepository, ISavedServiceRepository
    {
        public SavedServiceRepository(HolaGuide_TestContext dbContext) : base(dbContext) { }
        
        public SaveService? Get(Expression<Func<SaveService, bool>> predicate)
        {
            return DbContext.SaveServices.FirstOrDefault(predicate);
        }

        public List<SaveService> Gets(Expression<Func<SaveService, bool>> predicate)
        {
            return DbContext.SaveServices.Where(predicate).ToList();
        }
    }
}
