using Kaeshi.Entity;

namespace Kaeshi.Interfaces
{
    public interface IMap
    {
        Location GetCurrentLocation();
        void Go(Direction direction);
    }
}
