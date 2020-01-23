using System;
using System.Collections.Generic;
using System.Text;

namespace EventsLogger.Controllers
{
    public class ReadController
    {
        public string GetKey()
        {
            return Console.ReadKey(true).KeyChar.ToString();
        }

        public void WaitForKey()
        {
            if (!Console.IsOutputRedirected)
                GetKey();
        }
    }
}
