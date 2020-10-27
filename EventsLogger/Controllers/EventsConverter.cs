using System;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public class EventsConverter
    {
        public static PrintableEvent Create(Event evnt)
        {
            return new PrintableEvent
            {
                Color = SetColor(evnt.Type),
                Message = EventSerializer.Serialize(evnt)
            };
        }

        private static int SetColor(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.Error:
                    return (int) ConsoleColor.Red;
                case EventType.Step:
                    return (int)ConsoleColor.DarkGreen;
                case EventType.Information:
                    return (int)ConsoleColor.DarkBlue;
                default:
                    throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);
            }
        }

    }
}
