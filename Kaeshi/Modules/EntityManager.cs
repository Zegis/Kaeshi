using Keshi.Entity;
using Keshi.Interfaces;
using System.Collections.Generic;

namespace Keshi.Modules
{
    public class EntityManager
    {
        private  Dictionary<string, IVisible> visibleObjects = new Dictionary<string, IVisible>();
        private Map level;
        private Character hero;

        public void AddVisibleObject(string key, IVisible visibleObject)
        {
            visibleObjects.TryAdd(key, visibleObject);
        }

        public IVisible GetVisibleObject(string key)
        {
            if("around".Equals(key))
            {
                return level.GetCurrentLocation();
            }
            if ("yourself".Equals(key))
                return hero;

            IVisible npc = level.GetCurrentLocation().ObserveNpc(key);
            if (npc != null)
                return npc;

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

        internal IBattler GetTargetableObject(string rawTarget)
        {
            IBattler npc = level.GetCurrentLocation().TargetNpc(rawTarget);
            if (npc != null)
                return npc;

            return null;
        }
    }
}
