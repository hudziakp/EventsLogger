using System;
using System.Collections.Generic;
using EventsLogger.Models.System;

namespace EventsLogger.Controllers
{
    public class ConfigurationController : IConfigurationController
    {
        private Configuration _configuration;

        public ConfigurationController(string[] args)
        {
            var config = new Configuration
            {
                EmailConfiguration = new EmailConfiguration
                {
                    Enabled = true,
                    RecipientsList = new List<string> { "johndoe@email.com", "JackDaniels@test.emal"},
                    EmailCredentials = new EmailCredentials
                    {
                        Login = "John@email.com",
                        Password = "Secret",
                        Server = "smtp.email.com"
                    }
                },
                OutputConfiguration = new OutputConfiguration
                {
                    UseFileOutput = (args != null) &&
                                    (args.Length > 0) &&
                                    (args[0].Equals("File", StringComparison.InvariantCultureIgnoreCase))
                }
            };

            _configuration = config;
        }


        public Configuration GetConfiguration()
        {
            return _configuration;
        }

        public void SetConfiguration(Configuration configuration)
        {
            _configuration = configuration;
        }
    }
}
