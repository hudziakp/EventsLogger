using System.Collections.Generic;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public interface IEventLevelController
    {
        bool GetEventLevel();
        bool ShouldEventBeDisplayed(EventLevel eventLevel);
        IEnumerable<PrintableEvent> GetEventsToBePrinted(IEnumerable<Event> events);
    }
}