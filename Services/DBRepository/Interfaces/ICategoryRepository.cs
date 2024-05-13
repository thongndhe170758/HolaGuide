using Models.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Interfaces
{
    public interface ICategoryRepository
    {
        public List<Category> Gets(Expression<Func<Category, bool>> predicate);
        public Category? Get(Expression<Func<Category, bool>> predicate);
    }
}
