using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public class EventProcessing
    {
        private readonly EventRepository _eventRepository;
        private readonly ConfigurationLevelManager _configurationMgn;
        private readonly StandardIo _standardIo;
        public EventProcessing(
            EventRepository eventRepository, 
            ConfigurationLevelManager configurationMgn,
            StandardIo standardIo)
        {
            _eventRepository = eventRepository;
            _configurationMgn = configurationMgn;
            _standardIo = standardIo;
        }
        public void Process()
        {
            foreach (var e in _eventRepository.Events)
            {
                if (_configurationMgn.ValidateLevel(e))
                {
                    switch (e.Type)
                        {
                            case EventType.Error:
                                _standardIo.SetColor("Red");
                                break;
                            case EventType.Step:
                                _standardIo.SetColor("DarkGreen");
                                break;
                            case EventType.Information:
                                _standardIo.SetColor("DarkBlue");
                                break;
                        }
                    _standardIo.Write(e);
                    _standardIo.ResetColor();
                }
            }
        }
    }
}
