using System;
using System.Collections.Generic;
using System.Linq;
using EventsLogger.Controllers.PrintEvent;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers.EmailHander
{
    public class EmailController : PrintEventController
    {
        public string Server { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        private bool _shouldSendEmail = false;
        private string _emailAddress;

        public EmailController(IEventLevelController eventLevelController,IInputOutputController inputOutput) : base(eventLevelController, inputOutput)
        {
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
                Print(events);
            }
        }

        protected override void PrintEvents(IEnumerable<PrintableEvent> events)
        {
            _io.Send($"{events.Count()} events has been send to {_emailAddress}");
        }
    }
}
