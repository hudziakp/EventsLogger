using System.Collections.Generic;
using Autofac;
using EventsLogger.Controllers;
using EventsLogger.Dependency;
using EventsLogger.Models.Data;

namespace EventsLogger
{
    class Program
    {
        private static IContainer Container { get; set; }


        static void Main(string[] args)
        {
            var events = GenerateSampleData();
            var configurationController = new ConfigurationController(args);
            Container = DependenciesBuilder.PrepareContainer(configurationController);
            Execute(events);
        }

        private static void Execute(List<Event> events)
        {
            using var scope = Container.BeginLifetimeScope();
            var eventHandler = scope.Resolve<IEventHandler>();
            eventHandler.HandleEvents(events);
        }

        #region Event Genetation
        private static List<Event> GenerateSampleData()
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
