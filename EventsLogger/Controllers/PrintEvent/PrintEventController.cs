using System.Collections.Generic;
using System.Linq;
using EventsLogger.Helpers;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers.PrintEvent
{
    public abstract class PrintEventController : IPrintEventController
    {
        private readonly IEventLevelController _loggingLevel;
        protected readonly IInputOutputController _io;

        public PrintEventController(IEventLevelController eventLevelController, IInputOutputController io)
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