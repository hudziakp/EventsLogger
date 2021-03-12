using System.Collections.Generic;
using EventsLogger.Controllers.EmailHandler;
using EventsLogger.Controllers.PrintEvent;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{

    public class EventHandler : IEventHandler
    {
        private readonly IConfigurationController _configurationController;
        private readonly IEmailController _emailController;
        private readonly IEventLevelController _eventLevelController;
        private readonly IWorkflowController _workflowController;
        private readonly IPrintEventController _printEventController;
        public EventHandler(
            IConfigurationController configurationController, 
            IEmailController emailController, 
            IEventLevelController eventLevelController, 
            IWorkflowController workflowController, 
            IPrintEventController printEventController)
        {
            _configurationController = configurationController;
            _emailController = emailController;
            _eventLevelController = eventLevelController;
            _workflowController = workflowController;
            _printEventController = printEventController;
        }

        public void HandleEvents(List<Event> events)
        {
            if (!_eventLevelController.GetEventLevel())
                return;


            _printEventController.Print(events);

            var configuration = _configurationController.GetConfiguration();

            if (configuration?.EmailConfiguration?.Enabled ?? false)
            {
                _emailController.Recipients = configuration.EmailConfiguration?.RecipientsList;
                _emailController.SendEmail(events);
            }
            
            _workflowController.FinishApplication();
            
        }
    }
}
