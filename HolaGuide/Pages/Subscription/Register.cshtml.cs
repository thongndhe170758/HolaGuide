using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.SQLServer;
using Services.DBRepository.Interfaces;

namespace HolaGuide.Pages.Subcription
{
    [Authorize(Policy = "user")]
    public class RegisterModel : PageModel
    {
        private readonly ISubscriptionRepository _subscriptionRepos;
        private readonly IUserSubscriptionRepository _userSubscriptionRepos;
        public List<Models.SQLServer.Subscription> Subscriptions { get; set; }
        public List<int?> UserSubscription { get; set; }

        public RegisterModel(ISubscriptionRepository subscriptionRepos, IUserSubscriptionRepository userSubscriptionRepos)
        {
            _subscriptionRepos = subscriptionRepos;
            _userSubscriptionRepos = userSubscriptionRepos;
        }

        public void OnGet()
        {
            Subscriptions = _subscriptionRepos.Gets(_ => true).OrderBy(s => s.Price).ToList();
            var userid = int.Parse(User.Claims.First(c => c.Type == "ID").Value);
            UserSubscription = _userSubscriptionRepos.Gets(us => us.UserId == userid && us.IsPurchased && (us.EndDate == null || us.EndDate.Value <= DateTime.Today)).Select(us => us.SubscriptionId).ToList();
        }
    }
}
