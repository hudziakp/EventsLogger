using System.Collections.Generic;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public class PrintEventController
    {
        private readonly EventLevelController _loggingLevel;
        private readonly InputOutputController _io;
        public PrintEventController(EventLevelController eventLevelController, InputOutputController io)
        {
            _loggingLevel = eventLevelController;
            _io = io;
        }

        public void Print(IEnumerable<Event> events)
        {
            foreach (var e in events)
            {
                Print(e);
            }
        }

        private void Print(Event evnt)
        {
            if (_loggingLevel.ShouldEventBeDisplayed(evnt.Level))
            {
                using var printer = new PrinterController(evnt.Type, _io);
                printer.PrintLine(EventSerializer.Serialize(evnt));
            }
        }
    }
}
