using System;

namespace EventsLogger.Controllers
{
    public class WorkflowController : IWorkflowController
    {
        public void FinishApplication()
        {
            Console.WriteLine("============= Press Any Key to Finish ==============");
            Console.ReadKey();
            Console.WriteLine("Program Ended");
        }
    }
}