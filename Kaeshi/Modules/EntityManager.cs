using Keshi.Entity;
using Keshi.Interfaces;
using System.Collections.Generic;

namespace Keshi.Modules
{
    public class EntityManager
    {
        private  Dictionary<string, IVisible> visibleObjects = new Dictionary<string, IVisible>();
        private Map level;

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
            if (visibleObjects.TryGetValue(key, out var retVal))
                return retVal;

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

        internal ITargetable GetTargetableObject(string rawTarget)
        {
            ITargetable npc = level.GetCurrentLocation().TargetNpc(rawTarget);
            if (npc != null)
                return npc;

            return null;
        }
    }
}
