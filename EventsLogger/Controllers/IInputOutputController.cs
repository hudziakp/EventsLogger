namespace EventsLogger.Controllers
{
    public interface IInputOutputController
    {
        int GetColor();
        string ReadChar();
        string ReadLine();
        void Send(string text);
        void SetColor(int color);
    }
}