namespace Guide.Translate.Business.Notifications
{
    public interface  INotifyer
    {
        void Handle(Notify notificacao);
        List<Notify> GetNotifications();
        bool HasNotification();
    }
}
