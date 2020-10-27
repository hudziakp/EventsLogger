using System.IO;

namespace EventsLogger.Controllers
{
    public class FileLogger : ILogger
    {
        public string FilePath { get; set; } = @"C:\tmp\logFile.log";

        public int GetColor()
        {
            return 0;
        }

        public string ReadChar()
        {
            throw new System.NotImplementedException();
        }

        public void Send(string text)
        {
            File.AppendAllText(FilePath, text);
        }

        public void SetColor(int color)
        {
        }
    }
}
