using Keshi.Entity;
using Keshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (visibleObjects.TryGetValue(key, out var retVal))
                return retVal;

            return null;
        }

        public Map GetMap()
        {
            return level;
        }
    }
}
