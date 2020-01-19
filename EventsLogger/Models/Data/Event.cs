using System;

namespace EventsLogger.Models.Data
{
    public class Event
    {
        public DateTime EventDate { get; set; } = DateTime.Now;
        public EventType Type { get; set; } = EventType.Information;
        public EventLevel Level { get; set; } = EventLevel.Trace;
        public string Message { get; set; }
        public string Details { get; set; }
        public Event InnerEvent { get; set; }
    }
}
