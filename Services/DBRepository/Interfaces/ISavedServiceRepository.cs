using Models.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Interfaces
{
    public interface ISavedServiceRepository
    {
        public List<SaveService> Gets(Expression<Func<SaveService, bool>> predicate);
        public SaveService? Get(Expression<Func<SaveService, bool>> predicate);
    }
}
