using System.Collections.Generic;
using System.Linq;
using EventsLogger.Helpers;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers.PrintEvent
{
    public abstract class PrintEventController : IPrintEventController
    {
        protected readonly IEventLevelController _loggingLevel;
        protected readonly IInputOutputController _io;

        public PrintEventController(IEventLevelController eventLevelController, IInputOutputController io)
        {
            _loggingLevel = eventLevelController;
            _io = io;
        }

        public void Print(IEnumerable<Event> events)
        {
            PrintEvents(_loggingLevel.GetEventsToBePrinted(events));
        }

        protected abstract void PrintEvents(IEnumerable<PrintableEvent> events);
    }
}