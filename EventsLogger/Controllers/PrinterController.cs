using System;
using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public class PrinterController : IDisposable
    {
        int oldColor;
        private InputOutputController _output;
        public PrinterController(EventType eventType, InputOutputController output)
        {
            _output = output;
            oldColor = output.GetColor();
            switch (eventType)
            {
                case EventType.Error:
                    output.SetColor((int)ConsoleColor.Red);
                    break;
                case EventType.Step:
                    output.SetColor((int)ConsoleColor.DarkGreen);
                    break;
                case EventType.Information:
                    output.SetColor((int)ConsoleColor.DarkBlue);
                    break;
            }
        }

        public void PrintLine(string line)
        {
            _output.Send(line);
        }

        public void Dispose()
        {
            _output.SetColor(oldColor);
        }
    }
}
