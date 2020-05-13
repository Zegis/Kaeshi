using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Entity
{
    class Map
    {
        private readonly Dictionary<string, Location> locations;
        private Location current;

        public Map()
        {
            locations = LoadLocations();
        }

        private Dictionary<string, Location> LoadLocations()
        {
            var locations = new Dictionary<string, Location>();
            locations.Add("root", new Location());

            current = locations["root"];

            return locations;
        }

        public Location GetCurrentLocation()
        {
            return current;
        }
    }
}
