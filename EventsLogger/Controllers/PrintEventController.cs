using System.Collections.Generic;
using System.Linq;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public class PrintEventController
    {
        private readonly EventLevelController _loggingLevel;
        private readonly ILogger _io;
        public PrintEventController(EventLevelController eventLevelController, ILogger io)
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

        private void PrintEvents(IEnumerable<PrintableEvent> events)
        {
            var oldColor = _io.GetColor();
            foreach (var e in events)
            {
                _io.SetColor(e.Color);
                _io.Send(e.Message);
            }
            _io.SetColor(oldColor);
        }


        private static PrintableEvent Prepare(Event evnt)
        {
            return EventsConverter.Create(evnt);
        }
    }
}
