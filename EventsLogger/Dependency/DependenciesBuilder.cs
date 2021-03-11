using Autofac;
using EventsLogger.Controllers;
using EventsLogger.Controllers.EmailHandler;
using EventsLogger.Controllers.PrintEvent;

namespace EventsLogger.Dependency
{
    internal static class DependenciesBuilder
    {
        public static IContainer PrepareContainer( IConfigurationController configurationController)
        {
            var configuration = configurationController.GetConfiguration();
            var builder = new ContainerBuilder();
            builder.RegisterInstance(configurationController).As<IConfigurationController>();
            builder.RegisterType<InputOutputController>().As<IInputOutputController>().InstancePerLifetimeScope();
            builder.RegisterType<EventLevelController>().As<IEventLevelController>().InstancePerLifetimeScope();
            builder.RegisterType<EmailController>().As<IEmailController>().InstancePerLifetimeScope();
            builder.RegisterType<WorkflowController>().As<IWorkflowController>().InstancePerLifetimeScope();
            builder.RegisterType<EventHandler>().As<IEventHandler>();
            if(configuration?.OutputConfiguration?.UseFileOutput ?? false)
                builder.RegisterType<FilePrintEventController>().As<IPrintEventController>().InstancePerLifetimeScope();
            else
                builder.RegisterType<ConsolePrintEventController>().As<IPrintEventController>().InstancePerLifetimeScope();
            return builder.Build();
        }
    }
}
