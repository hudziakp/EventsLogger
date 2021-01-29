using System;
using System.Collections.Generic;
using System.Linq;
using EventsLogger.Helpers;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public class EventLevelController : IEventLevelController
    {
        private readonly InputOutputController _io;
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
                if ((int)logLevel < Enum.GetValues(typeof(EventLevel)).Length)
                {
                    _logLevel = logLevel;
                    return true;
                }
            }
            _io.Send($"\"{element}\" is not valid value.");
            return false;
        }

        public bool ShouldEventBeDisplayed(EventLevel eventLevel)
        {
            return eventLevel >= _logLevel;
        }

        public IEnumerable<PrintableEvent> GetEventsToBePrinted(IEnumerable<Event> events)
        {
            return from e in events
                where ShouldEventBeDisplayed(e.Level)
                select Prepare(e);
        }

        private static PrintableEvent Prepare(Event evnt)
        {
            return EventsConverter.Create(evnt);
        }
    }
}
