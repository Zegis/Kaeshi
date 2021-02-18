using Keshi.Entity;

namespace Keshi.Interfaces
{
    public interface IMap
    {
        Location GetCurrentLocation();
        void Go(Direction direction);
    }
}
