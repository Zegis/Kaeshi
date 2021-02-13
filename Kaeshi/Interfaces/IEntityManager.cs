using Keshi.Entity;
using Keshi.Interfaces;

namespace Keshi.Modules
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