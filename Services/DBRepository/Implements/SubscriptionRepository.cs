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
    public class SubscriptionRepository : BaseRepository, ISubscriptionRepository
    {
        public SubscriptionRepository(HolaGuide_TestContext HolaGuide_TestContext) : base(HolaGuide_TestContext) { }

        public List<Subscription> Gets(Expression<Func<Subscription, bool>> predicate)
        {
            return DbContext.Subscriptions.Where(predicate).ToList();
        }

        public Subscription? Get(Expression<Func<Subscription, bool>> predicate)
        {
            return DbContext.Subscriptions.FirstOrDefault(predicate);
        }
    }
}
