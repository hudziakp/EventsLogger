using EventsLogger.Models.Data;
using System;
using System.Collections.Generic;

using System.Text;

namespace EventsLogger.Controllers
{
    public class EventsController
    {
        private EventLevel _eventLevel;
        private WriteController _writeController;
        private ReadController _readController;
        public EventsController(WriteController writeController, ReadController readController)
        {
            _writeController = writeController;
            _readController = readController;
        }

        public void DisplayEventLevelTypes()
        {
            var i = 0;
            foreach (var level in Enum.GetValues(typeof(EventLevel)))
            {
                _writeController.WriteLine($"{i++}. {level}");
            }
        }

        public bool GetEventLevel()
        {
            var element = _readController.GetKey();
            if (!Enum.TryParse<EventLevel>(element, out _eventLevel))
            {
                _writeController.WriteLine($"\"{element}\" is not valid value.");
                return false;
            }

            if ((int)_eventLevel > Enum.GetValues(typeof(EventLevel)).Length)
            {
                _writeController.WriteLine($"\"{element}\" is not valid value.");
                return false;
            }

            return true;
        }

        public bool EventLevelCheck(Event evnt)
        {
            return evnt.Level >= _eventLevel;
        }
    }
}
