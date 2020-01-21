using System.Collections.Generic;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public class PrintEventController
    {
        EventLevelController _loggingLevel;
        InputOutputController _io;
        public PrintEventController(EventLevelController eventLevelController, InputOutputController io)
        {
            _loggingLevel = eventLevelController;
            _io = io;
        }

        public void Print(List<Event> events)
        {
            foreach (var e in events)
            {
                Print(e);
            }
        }

        public void Print(Event evnt)
        {
            if (_loggingLevel.ShouldEventBeDisplayed(evnt.Level))
            {
                using var printer = new PrinterController(evnt.Type, _io);
                printer.PrintLine(EventSerializer.Serialize(evnt));
            }
        }
    }
}
