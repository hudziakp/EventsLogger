using EventsLogger.Models.System;

namespace EventsLogger.Controllers
{
    public interface IConfigurationController
    {
        public Configuration GetConfiguration();
        public void SetConfiguration(Configuration configuration);
    }
}
