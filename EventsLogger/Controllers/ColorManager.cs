using System;
using System.Collections.Generic;
using System.Text;

namespace EventsLogger.Controllers
{
    public class ColorManager
    {
        private ConsoleColor defaultColor = ConsoleColor.White;

        public void SetColor(string color)
        {
            defaultColor = Console.ForegroundColor;
            {
                if (Enum.TryParse<ConsoleColor>(color, out var consoleColor))
                    Console.ForegroundColor = consoleColor;
            }
        }

        public void ResetColor()
        {
            Console.ForegroundColor = defaultColor;
        }
    }
}
