using EventsLogger.Controllers;

namespace EventsLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventGenerator  = new EventGenerator();
            var eventRepository = new EventRepository();
            var standardIo = new StandardIo();
            var configurationMgn = new ConfigurationLevelManager(standardIo);
            var eventProcessing = new EventProcessing(eventRepository, configurationMgn, standardIo);
            
            eventRepository.AddEvents(eventGenerator.GenerateSampleData());
            if (!configurationMgn.GetLoggingLevel())
                return;
            eventProcessing.Process();
            standardIo.Read();
        }
    }
}
