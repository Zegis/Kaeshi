using Kaeshi.Entity;

namespace Kaeshi.Interfaces
{
    public interface IEntityManager
    {
        void AddVisibleObject(string key, IVisible visibleObject);
        Character GetHero();
        Map GetMap();
        IVisible GetVisibleObject(string key);
        void SetHero(Character hero);
        void SetMap(Map map);
        IBattler GetTargetableObject(string rawTarget);
    }
}