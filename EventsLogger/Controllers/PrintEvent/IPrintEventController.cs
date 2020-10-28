using System.Collections.Generic;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers.PrintEvent
{
    public interface IPrintEventController
    {
        void Print(IEnumerable<Event> events);
    }
}