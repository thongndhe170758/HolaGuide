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
        public User? Get(Expression<Func<User, bool>> predicate);
        public List<User> Gets(Expression<Func<User, bool>> predicate);
        public string Create(User user);
        public string UpdateActivation(User updateUser);
    }
}
