using System.Collections.Generic;
using System.Linq;
using EventsLogger.Helpers;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers.PrintEvent
{
    public abstract class PrintEventController : IPrintEventController
    {
        private readonly EventLevelController _loggingLevel;
        protected readonly InputOutputController _io;

        public PrintEventController(EventLevelController eventLevelController, InputOutputController io)
        {
            _loggingLevel = eventLevelController;
            _io = io;
        }

        public void Print(IEnumerable<Event> events)
        {
            var eventsToBeDisplayed = from e in events
                where _loggingLevel.ShouldEventBeDisplayed(e.Level)
                select Prepare(e);

            PrintEvents(eventsToBeDisplayed);
        }

        protected abstract void PrintEvents(IEnumerable<PrintableEvent> events);

        private static PrintableEvent Prepare(Event evnt)
        {
            return EventsConverter.Create(evnt);
        }
    }
}
