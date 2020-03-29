using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AgendaVoluntaria.Api.Utils
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notifications;
        public Notifier()
        {
            _notifications = new List<Notification>();
        }
        public void Add(string message)
        {
            _notifications.Add(new Notification(message));
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HaveNotification()
        {
            return _notifications.Any();
        }
    }
}
