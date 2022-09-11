using Kaeshi.Entity;

namespace Kaeshi.Interfaces
{
    public interface IMap
    {
        Location GetCurrentLocation();
        bool Go(Direction direction);
    }
}
