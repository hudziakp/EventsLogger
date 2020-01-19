using System;
using System.Collections.Generic;
using EventsLogger.Models.Data;

namespace EventsLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var events = new List<Event>();
            Console.WriteLine("Event Logger App");
            Console.WriteLine("Select Logging Level:");
            var i = 0;
            foreach (var level in Enum.GetValues(typeof(EventLevel)))
            {
                Console.WriteLine($"{i++}. {level}");
            }

            var element = Console.ReadKey(true).KeyChar.ToString();
            var logLevel = EventLevel.Trace;
            if (!Enum.TryParse<EventLevel>(element, out logLevel))
            {
                Console.WriteLine($"\"{element}\" is not valid value.");
                return;
            }

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
                Details = "Connected to datasorce XXX successfully"
            });

            foreach (var e in events)
            {
                if (e.Level >= logLevel)
                {
                    var oldColor = Console.ForegroundColor;
                    if (!Console.IsOutputRedirected)
                        switch (e.Type)
                        {
                            case EventType.Error:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case EventType.Step:
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case EventType.Information:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                        }

                    Console.WriteLine("===========================================================");
                    Console.WriteLine($"[{e.EventDate:HH:mm:ss}] \n Type: {e.Type} \n Level: {e.Level} \n   Message: {e.Message}\n   Details: {e.Details} ");
                    var innerEvent = e.InnerEvent;
                    var innerLevel = 0;
                    while (innerEvent != null)
                    {
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine($"INNER EVENT Level {innerLevel++} \n  Type: {innerEvent.Type}\n  Level: {innerEvent.Level} \n   Message: {innerEvent.Message}\n   Details: {innerEvent.Details} ");
                        innerEvent = innerEvent.InnerEvent;
                    }

                    Console.ForegroundColor = oldColor;
                }
            }
            if (!Console.IsOutputRedirected)
                Console.ReadKey(true);
        }
    }
}
