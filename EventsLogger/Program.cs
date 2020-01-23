using System;
using System.Collections.Generic;
using EventsLogger.Controllers;
using EventsLogger.Models.Data;

namespace EventsLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var readController = new ReadController();
            var writeController = new WriteController();
            var colorManager = new ColorManager();
            var eventController = new EventsController(writeController, readController);
            var displayEventsController = new DisplayEventsController(
                eventController, 
                writeController, 
                readController,
                colorManager);

            var events = GenerateSampleData();
            writeController.WriteLine("Event Logger App");
            writeController.WriteLine("Select Logging Level:");
            eventController.DisplayEventLevelTypes();
            if (eventController.GetEventLevel())
                displayEventsController.Display(events);
        }

        static List<Event> GenerateSampleData()
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
