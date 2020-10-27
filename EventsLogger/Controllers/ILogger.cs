namespace EventsLogger.Controllers
{
    public interface ILogger
    {
        int GetColor();
        string ReadChar();
        void Send(string text);
        void SetColor(int color);
    }
}