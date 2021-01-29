using System;
using System.Collections.Generic;
using EventsLogger.Controllers;
using EventsLogger.Controllers.EmailHander;
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
            var mailController = new EmailController(loggingLevel, io)
            {
                Login = "John@email.com",
                Password = "Secret",
                Server = "smtp.email.com"
            };

            if (!loggingLevel.GetEventLevel())
                return;

            printer.Print(events);

            //send to Email
            mailController.ShouldSendEmail();
            mailController.SendEmail(events);

            //Closing statements
            io.ReadChar();
            io.Send("Program Ended");
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
