using System;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public class StandardIo
    {
        private ConsoleColor _oldColor = ConsoleColor.White;

        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(Event e)
        {
            Write("===========================================================");
            Write($"[{e.EventDate:HH:mm:ss}] \n Type: {e.Type} \n Level: {e.Level} \n   Message: {e.Message}\n   Details: {e.Details} ");
            var innerEvent = e.InnerEvent;
            var innerLevel = 0;
            while (innerEvent != null)
            {
                Write("---------------------------------------------------------");
                Write($"INNER EVENT Level {innerLevel++} \n  Type: {innerEvent.Type}\n  Level: {innerEvent.Level} \n   Message: {innerEvent.Message}\n   Details: {innerEvent.Details} ");
                innerEvent = innerEvent.InnerEvent;
            }
        }

        public string Read()
        {
            return !Console.IsOutputRedirected ?
                Console.ReadKey(true).KeyChar.ToString() :
                null;
        }

        public void SetColor(string color)
        {
            if (Enum.TryParse<ConsoleColor>(color, out var consoleColor) && 
                !Console.IsOutputRedirected)
            {
                _oldColor = Console.ForegroundColor;
                Console.ForegroundColor = consoleColor;
            }
        }

        public void ResetColor()
        {
            if (!Console.IsOutputRedirected)
                Console.ForegroundColor = _oldColor;
        }
    }
}
