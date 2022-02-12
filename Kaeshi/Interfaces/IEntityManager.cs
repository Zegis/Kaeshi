using Kaeshi.Entity;

namespace Kaeshi.Interfaces
{
    public interface IEntityManager
    {
        Character GetHero();
        Map GetMap();
        IVisible GetVisibleObject(string key);
        void SetHero(Character hero);
        void SetMap(Map map);
        IBattler GetTargetableObject(string rawTarget);
        Item GetItem(string rawTarget);
    }
}