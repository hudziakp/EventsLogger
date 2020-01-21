using System;
namespace EventsLogger.Controllers
{
    public class InputOutputController
    {
        public void Send(string text)
        {
            Console.WriteLine(text);
        }

        public int GetColor()
        {
            return Console.IsOutputRedirected ? 0 : (int)Console.ForegroundColor;
        }

        public void SetColor(int color)
        {
            if (!Console.IsOutputRedirected)
                Console.ForegroundColor = (ConsoleColor)color;
        }

        public string ReadChar()
        {
            return Console.ReadKey(true).KeyChar.ToString();
        }
    }
}
