using Infrastructure.SQLServer;
using Microsoft.EntityFrameworkCore;
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
    public class UserSubscriptionRepository : BaseRepository, IUserSubscriptionRepository
    {
        public UserSubscriptionRepository(HolaGuide_TestContext HolaGuide_TestContext) : base(HolaGuide_TestContext) { }

        public List<UserSubscription> Gets(Expression<Func<UserSubscription, bool>> predicate)
        {
            return DbContext.UserSubscriptions.Include(u => u.Subscription).Where(predicate).ToList();
        }

        public string Create(UserSubscription? userSubscription)
        {
            if (userSubscription == null) return "Data can not be null";
            try
            {
                DbContext.UserSubscriptions.Add(userSubscription);
                var result = DbContext.SaveChanges();
                if (result != 0) return "Hệ thống đang kiểm tra, tài khoản của bạn sẽ được cập nhật trong vài giờ tới.";
                return "Lõi hệ thống";
            }
            catch(Exception ex)
            {
                return ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
        }
    }
}
