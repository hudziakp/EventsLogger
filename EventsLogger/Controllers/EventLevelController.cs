using System;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public class EventLevelController
    {
        private InputOutputController _io;
        private EventLevel _logLevel;
        public EventLevelController(InputOutputController io)
        {
            _io = io;
        }
        public bool GetEventLevel()
        {
            _io.Send("Event Logger App");
            _io.Send("Select Logging Level:");
            var i = 0;
            foreach (var level in Enum.GetValues(typeof(EventLevel)))
            {
                _io.Send($"{i++}. {level}");
            }

            var element = _io.ReadChar();
            if (Enum.TryParse(element, out EventLevel logLevel))
            {
                _logLevel = logLevel;
                return true;
            }
            _io.Send($"\"{element}\" is not valid value.");
            return false;
        }

        public bool ShouldEventBeDisplayed(EventLevel eventLevel)
        {
            return eventLevel >= _logLevel;
        }
    }
}
