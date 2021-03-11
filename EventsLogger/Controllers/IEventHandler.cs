using System.Collections.Generic;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public interface IEventHandler
    {
        void HandleEvents(List<Event> events);
    }
}
