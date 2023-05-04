namespace Guide.Translate.Business.Notifications
{
    public class Notify
    {
        public Notify(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
