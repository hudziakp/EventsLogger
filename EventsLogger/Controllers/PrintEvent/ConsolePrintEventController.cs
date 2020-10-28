using System.Collections.Generic;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers.PrintEvent
{
    public class ConsolePrintEventController : PrintEventController
    {
        public ConsolePrintEventController(EventLevelController eventLevelController, InputOutputController io): base(eventLevelController, io) {
        }

        protected override void PrintEvents(IEnumerable<PrintableEvent> events)
        {
            var oldColor = _io.GetColor();
            foreach (var e in events)
            {
                _io.SetColor(e.Color);
                _io.Send(e.Message);
            }
            _io.SetColor(oldColor);
        }
    }
}
