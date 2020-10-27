using System.Text;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public class EventSerializer
    {
        public static string Serialize(Event evnt)
        {
            var builder = new StringBuilder();
            builder.AppendLine("===========================================================");
            builder.AppendLine(SerializeLine(evnt));
            var innerEvent = evnt.InnerEvent;
            var innerLevel = 0;
            while (innerEvent != null)
            {
                builder.AppendLine("---------------------------------------------------------");
                builder.AppendLine($"INNER EVENT Level {innerLevel++} \n  {SerializeLine(innerEvent)}");
                innerEvent = innerEvent.InnerEvent;
            }

            return builder.ToString();
        }

        private static string SerializeLine(Event evnt)
        {
            return $"[{evnt.EventDate:HH:mm:ss}] \n Type: {evnt.Type} \n Level: {evnt.Level} \n   Message: {evnt.Message}\n   Details: {evnt.Details} ";
        }
    }
}
