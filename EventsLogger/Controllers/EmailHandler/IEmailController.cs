using EventsLogger.Models.Data;
using System.Collections.Generic;

namespace EventsLogger.Controllers.EmailHandler
{
    public interface IEmailController
    {
        string Login { get; set; }
        string Password { get; set; }
        string Server { get; set; }
        List<string> Recipients { get; set; }

        void SendEmail(IEnumerable<Event> events);
    }
}