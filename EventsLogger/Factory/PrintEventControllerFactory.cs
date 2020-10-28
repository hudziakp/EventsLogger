using EventsLogger.Controllers;
using EventsLogger.Controllers.PrintEvent;

namespace EventsLogger.Factory
{
    public class PrintEventControllerFactory
    {
        public static IPrintEventController Generate(bool isFile, EventLevelController loggingLevel, InputOutputController io)
        {
            if (isFile)
                return new FilePrintEventController(loggingLevel, io);
            else
                return new ConsolePrintEventController(loggingLevel, io);
        }
    }
}
