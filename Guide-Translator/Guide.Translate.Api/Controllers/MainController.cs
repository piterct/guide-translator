using Guide.Translate.Business.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Guide.Translate.Api.Controllers
{
    public abstract class MainController : Controller
    {
        private readonly INotifyer _notifyer;

        public MainController(INotifyer notifyer)
        {
            _notifyer = notifyer;
        }

        protected bool InvalidOperation()
        {
            return !_notifyer.HasNotification();
        }
    }
}
