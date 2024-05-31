using Models.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBRepository.Interfaces
{
    public interface ISubscriptionRepository
    {
        public List<Subscription> Gets(Expression<Func<Subscription, bool>> predicate);
        public Subscription? Get(Expression<Func<Subscription, bool>> predicate);
    }
}
