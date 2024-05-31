using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.SQLServer;
using Services.DBRepository.Interfaces;

namespace HolaGuide.Pages.Subscription
{

    [Authorize(Policy = "user")]
    public class CheckoutModel : PageModel
    {
        private readonly ISubscriptionRepository _subscriptionRepos;
        private readonly IUserSubscriptionRepository _userSubscriptionRepos;
        public Models.SQLServer.Subscription SelectedSubscription { get; set; } 

        public CheckoutModel(ISubscriptionRepository subscriptionRepos, IUserSubscriptionRepository userSubscriptionRepos)
        {
            _subscriptionRepos = subscriptionRepos;
            _userSubscriptionRepos = userSubscriptionRepos;
        }

        public IActionResult OnGet([FromRoute]int subscriptionId)
        {
            var subscription = _subscriptionRepos.Get(s => s.Id == subscriptionId);
            if(subscription == null) return RedirectToPage("/Static/NotFound");
            SelectedSubscription = subscription;
            return Page();
        }

        public IActionResult OnPost(int userId, int subscriptionId)
        {
            var subscription = _subscriptionRepos.Get(s => s.Id == subscriptionId);
            var userSubscription = new UserSubscription
            {
                UserId = userId,
                SubscriptionId = subscriptionId,
                StartDate = DateTime.Now,
                EndDate = subscription.DurationDays == null ? null : DateTime.Now.AddDays(subscription.DurationDays.Value),
            };
            _userSubscriptionRepos.Create(userSubscription);
            return RedirectToPage("/Home/UserHome");
        }
    }
}
