using System;
using EventsLogger.Models.Data;
using System.Collections.Generic;

namespace EventsLogger.Controllers.EmailHandler
{
    public interface IEmailController
    {
        string Login { get; set; }
        string Password { get; set; }
        string Server { get; set; }
        List<string> Recipients { get; set; }

        void SendEmail(IEnumerable<Event> events);
    }


    public interface IWebPage : IBrowserTab, IPage
    {
        string Type { get; set; } // = "Incognito"
    }

    public interface IBrowserTab
    {
        string Handle { get; set; }
    }

    public interface IPage
    {
        string Url { get; set; }
    }

    public class MainPage : IWebPage
    {
        public string Handle { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
    }

    public class TestSth
    {
        public void MainSth()
        {
            var page = new MainPage
            {
                Handle = Guid.NewGuid().ToString(),
                Url = "http://home.com"
            };

            SwitchToTab(page);
        }

        public void SwitchToTab(IBrowserTab tab)
        {

        }


    }
}