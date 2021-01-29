using System;
using System.Collections.Generic;
using System.Linq;
using EventsLogger.Controllers.PrintEvent;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers.EmailHandler
{
    public class EmailController : IEmailController
    {
        public string Server { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        private bool _shouldSendEmail = false;
        private string _emailAddress;

        private readonly IInputOutputController _io;
        private readonly IEventLevelController _loggingLevel;

        public EmailController(IEventLevelController eventLevelController, IInputOutputController inputOutput)
        {
            _io = inputOutput;
            _loggingLevel = eventLevelController;
        }

        public void ShouldSendEmail()
        {
            _io.Send("Should send email? (Y/N)");
            var shouldSend = _io.ReadChar();
            if (shouldSend.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
            {
                _shouldSendEmail = true;
            }
        }

        public void SendEmail(IEnumerable<Event> events)
        {
            if (_shouldSendEmail)
            {
                _io.Send("Provide Email Address:");
                _emailAddress = _io.ReadLine();
                var eventsToSend =_loggingLevel.GetEventsToBePrinted(events);
                _io.Send($"{eventsToSend.Count()} events has been send to {_emailAddress}");
            }
        }
    }
}
