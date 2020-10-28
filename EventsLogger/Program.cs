using System;
using System.Collections.Generic;
using EventsLogger.Controllers;
using EventsLogger.Factory;
using EventsLogger.Models.Data;

namespace EventsLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var toFile = (args != null) && 
                         (args.Length > 0) && 
                         (args[0].Equals("File",StringComparison.InvariantCultureIgnoreCase));

            var events = new List<Event>(GenerateSampleData());
            var io = new InputOutputController();
            var loggingLevel = new EventLevelController(io);
            var printer = PrintEventControllerFactory.Generate(toFile, loggingLevel, io);

            if (!loggingLevel.GetEventLevel())
                return;

            printer.Print(events);
            io.ReadChar();
        }

        #region Event Genetation
        private static IEnumerable<Event> GenerateSampleData()
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
        #endregion Event Generation
    }
}
