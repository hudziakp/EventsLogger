using EventsLogger.Models.Data;
using System;

namespace EventsLogger.Controllers
{
    public class ConfigurationLevelManager
    {
        private EventLevel _currentLogLevel;
        private readonly StandardIo _io;
        public ConfigurationLevelManager(StandardIo io)
        {
            _io = io;
        }

        public bool GetLoggingLevel()
        {
            _io.Write("Event Logger App");
            _io.Write("Select Logging Level:");
            var i = 0;
            foreach (var level in Enum.GetValues(typeof(EventLevel)))
            {
                _io.Write($"{i++}. {level}");
            }

            var element = _io.Read();
            if (!Enum.TryParse(element, out EventLevel logLevel) || 
                (int)logLevel >= Enum.GetValues(typeof(EventLevel)).Length)
            {
                _io.Write($"\"{element}\" is not valid value.");
                return false;
            }
            _currentLogLevel = logLevel;
            return true;
        }

        public bool ValidateLevel(Event evnt)
        {
            return evnt.Level >= _currentLogLevel;
        }
    }
}
