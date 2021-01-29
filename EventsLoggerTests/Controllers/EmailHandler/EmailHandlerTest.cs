using System;
using System.Collections.Generic;
using EventsLogger.Controllers;
using EventsLogger.Controllers.EmailHandler;
using EventsLogger.Models.Data;
using Moq;
using Xunit;

namespace EventsLoggerTests.Controllers.EmailHandler
{
    public class EmailHandlerTest
    {
        [Fact]
        public void SendEmailTest()
        {
            var loggingLevel = new Mock<IEventLevelController>();
            loggingLevel.Setup(l => l.ShouldEventBeDisplayed(It.IsAny<EventLevel>())).Returns(true);
            var io = new Mock<IInputOutputController>();
            io.Setup(i => i.ReadChar()).Returns("Y");
            io.Setup(i => i.ReadLine()).Returns("Johnny@email.com");
            io.Setup(i => i.Send(It.IsAny<string>()));

            var events = new List<Event>
            {
                new Event{Details = string.Empty, Level = EventLevel.Info, EventDate = DateTime.Now, Message = string.Empty, Type = EventType.Information}
            };

            var mailController = new EmailController(loggingLevel.Object, io.Object);
            mailController.ShouldSendEmail();
            io.Verify(i => i.Send("Should send email? (Y/N)"), Times.Once);

            mailController.SendEmail(events);
            io.Verify(i => i.Send("Provide Email Address:"), Times.Once);
            io.Verify(i => i.Send("1 events has been send to Johnny@email.com"), Times.Once);
        }
    }
}