using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System.Collections.Generic;

namespace Kaeshi.Modules
{
    public class EntityManager : IEntityManager
    {
        private Dictionary<string, IVisible> visibleObjects = new Dictionary<string, IVisible>();
        private Map level;
        private Character hero;

        public void AddVisibleObject(string key, IVisible visibleObject)
        {
            visibleObjects.TryAdd(key, visibleObject);
        }

        public IVisible GetVisibleObject(string key)
        {
            if ("around".Equals(key))
            {
                return level.GetCurrentLocation();
            }
            if ("yourself".Equals(key))
                return hero;

            IVisible target = level.GetCurrentLocation().ObserveNpc(key);
            if (target != null)
                return target;

            target = level.GetCurrentLocation().ObserveItem(key);

            if (target != null)
                return target;

            return null;
        }

        public Map GetMap()
        {
            return level;
        }

        public void SetMap(Map map)
        {
            level = map;
        }

        public void SetHero(Character hero)
        {
            this.hero = hero;
        }

        public Character GetHero()
        {
            return hero;
        }

        public IBattler GetTargetableObject(string rawTarget)
        {
            IBattler npc = level.GetCurrentLocation().TargetNpc(rawTarget);
            if (npc != null)
                return npc;

            return null;
        }

        public Item GetItem(string rawTarget)
        {
            Item item = level.GetCurrentLocation().GetItem(rawTarget);
            if (item != null)
                return item;

            return null;
        }
    }
}
