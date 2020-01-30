using EventsLogger.Models.Data;
using System.Collections.Generic;

namespace EventsLogger.Controllers
{
    public class EventRepository
    {
        public List<Event> Events { get; } = new List<Event>();

        public void AddEvents(IEnumerable<Event> events)
        {
            Events.AddRange(events);
        }
    }
}
