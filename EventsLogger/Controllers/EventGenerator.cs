using EventsLogger.Models.Data;
using System.Collections.Generic;

namespace EventsLogger.Controllers
{
    public class EventGenerator
    {
        public List<Event> GenerateSampleData()
        {
            var events = new List<Event>();
            var evnt = new Event
            {
                Level = EventLevel.Trace,
                Type = EventType.Information,
                Message = "Something",
                Details = "More Info"
            };

            events.Add(new Event
            {
                Level = EventLevel.Info,
                Type = EventType.Information,
                Message = "Information Event",
                Details = "Outer Information Event",
                InnerEvent = evnt
            });

            events.Add(new Event
            {
                Level = EventLevel.Error,
                Type = EventType.Error,
                Message = "Error Message",
                Details = "Error Message Details"
            });

            events.Add(new Event
            {
                Level = EventLevel.Info,
                Type = EventType.Step,
                Message = "Execution Step 1",
                Details = "Details to first Execution Step"
            });

            events.Add(new Event
            {
                Level = EventLevel.Trace,
                Type = EventType.Information,
                Message = "Connection established",
                Details = "Connected to data source XXX successfully"
            });

            return events;
        }
    }
}
