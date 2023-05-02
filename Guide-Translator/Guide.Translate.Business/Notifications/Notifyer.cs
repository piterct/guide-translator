namespace Guide.Translate.Business.Notifications
{
    public class Notifyer : INotifyer
    {
        private List<Notify> _notifications;

        public Notifyer()
        {
            _notifications = new List<Notify>();
        }

        public void Handle(Notify notificacao)
        {
            _notifications.Add(notificacao);
        }

        public List<Notify> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
