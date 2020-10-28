using System.Collections.Generic;
using System.IO;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers.PrintEvent
{
    public class FilePrintEventController : PrintEventController
    {
        public string FilePath { get; set; } = @"C:\tmp\EventLoggerText.log";

        public FilePrintEventController(EventLevelController eventLevelController, InputOutputController io) : base(eventLevelController, io)
        {
        }

        protected override void PrintEvents(IEnumerable<PrintableEvent> events)
        {
            DeleteFileIfExist();
            foreach (var e in events)
            {
                File.AppendAllText(FilePath, e.Message);
            }
        }

        private void DeleteFileIfExist()
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }
    }
}
