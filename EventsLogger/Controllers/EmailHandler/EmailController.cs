using System.Collections.Generic;
using System.Linq;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers.EmailHandler
{
    public class EmailController : IEmailController
    {
        public string Server { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<string> Recipients { get; set; }

        private readonly IInputOutputController _io;
        private readonly IEventLevelController _loggingLevel;

        public EmailController(IEventLevelController eventLevelController, IInputOutputController inputOutput)
        {
            _io = inputOutput;
            _loggingLevel = eventLevelController;
        }

        public void SendEmail(IEnumerable<Event> events)
        {
            var eventsToSend = _loggingLevel.GetEventsToBePrinted(events);
            foreach (var recipient in Recipients)
            {
                _io.Send($"{eventsToSend.Count()} events has been send to {recipient}");
            }
            
        }
    }
}
