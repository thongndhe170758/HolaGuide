using Models.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Interfaces
{
    public interface IUserSubscriptionRepository
    {
        public List<UserSubscription> Gets(Expression<Func<UserSubscription, bool>> predicate);
        public string Create(UserSubscription? userSubscription);
    }
}
