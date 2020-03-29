using AgendaVoluntaria.Api.Models;
using System.Collections.Generic;

namespace AgendaVoluntaria.Api.Utils.Interfaces
{
    public interface INotifier
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Add(string message);
    }
}
