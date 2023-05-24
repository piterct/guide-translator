using Guide.Translate.Business.Notifications;

namespace Guide.Translate.Business.Services
{
    public abstract class BaseService
    {
        private INotifyer _notifyer;

        public BaseService(INotifyer notifyer)
        {
            _notifyer = notifyer;
        }

        protected bool InvalidOperation()
        {
            return !_notifyer.HasNotification();
        }

        protected void Notify(string message)
        {
            _notifyer.Handle(new Notify(message));
        }
    }
}
