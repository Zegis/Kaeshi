using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Entity
{
    public class Map
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
            locations.Add("north1", new Location());

            current = locations["root"];
            current.SetLink(Direction.North, locations["north1"]);

            return locations;
        }

        public Location GetCurrentLocation()
        {
            return current;
        }

        public void Go(Direction direction)
        {
            var newLocation = current.GetLink(direction);
            if (newLocation != null)
                current = newLocation;
        }
    }
}
