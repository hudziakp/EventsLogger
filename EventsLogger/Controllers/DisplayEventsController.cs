using EventsLogger.Models.Data;
using System.Collections.Generic;

namespace EventsLogger.Controllers
{
    public class DisplayEventsController
    {
        private EventsController _eventsController;
        private WriteController _writeController;
        private ReadController _readController;
        private ColorManager _colorManager;

        public DisplayEventsController(
            EventsController eventsController,
            WriteController writeController,
            ReadController readController,
            ColorManager colorManager)
        {
            _eventsController = eventsController;
            _writeController = writeController;
            _readController = readController;
            _colorManager = colorManager;
        }

        public void Display(List<Event> events)
        {
            foreach (var e in events)
            {
                if (_eventsController.EventLevelCheck(e))
                {
                    DisplayEvent(e);
                }
            }
            _readController.WaitForKey();
        }

        private void DisplayEvent(Event e)
        {
            SetColor(e);
            _writeController.WriteLine("===========================================================");
            _writeController.WriteLine(
                $"[{e.EventDate:HH:mm:ss}] \n Type: {e.Type} \n Level: {e.Level} \n   Message: {e.Message}\n   Details: {e.Details} ");
            var innerEvent = e.InnerEvent;
            var innerLevel = 0;
            while (innerEvent != null)
            {
                _writeController.WriteLine("---------------------------------------------------------");
                _writeController.WriteLine(
                    $"INNER EVENT Level {innerLevel++} \n  Type: {innerEvent.Type}\n  Level: {innerEvent.Level} \n   Message: {innerEvent.Message}\n   Details: {innerEvent.Details} ");
                innerEvent = innerEvent.InnerEvent;
            }

            _colorManager.ResetColor();
        }

        private void SetColor(Event e)
        {
            switch (e.Type)
            {
                case EventType.Error:
                    _colorManager.SetColor("Red");
                    break;
                case EventType.Step:
                    _colorManager.SetColor("DarkGreen");
                    break;
                case EventType.Information:
                    _colorManager.SetColor("DarkBlue");
                    break;
            }
        }
    }
}
