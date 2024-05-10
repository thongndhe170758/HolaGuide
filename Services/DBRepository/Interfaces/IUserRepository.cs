using Models.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> Get(Expression<Func<User, bool>> predicate);
        public Task<List<User>> Gets(Expression<Func<User, bool>> predicate);
    }
}
