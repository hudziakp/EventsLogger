using System.Collections.Generic;

namespace EventsLogger.Models.System
{
    public class EmailConfiguration
    {
        public bool Enabled { get; set; }
        public List<string> RecipientsList { get; set; }
        public EmailCredentials EmailCredentials { get; set; }
    }
}
