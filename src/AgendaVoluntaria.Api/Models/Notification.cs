namespace AgendaVoluntaria.Api.Models
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
