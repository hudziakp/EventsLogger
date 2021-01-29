using EventsLogger.Models.Data;

namespace EventsLogger.Controllers
{
    public interface IEventLevelController
    {
        bool GetEventLevel();
        bool ShouldEventBeDisplayed(EventLevel eventLevel);
    }
}