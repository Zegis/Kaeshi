using Kaeshi.Interfaces;
using Kaeshi.Modules;
using System;
using System.Collections.Generic;

namespace Kaeshi.Entity
{
    public class Map : IMap
    {
        private Location current;

        public Map()
        {
            LoadLocations();
        }

        private Dictionary<string, Location> LoadLocations()
        {
            var locations = new Dictionary<string, Location>();
            locations.Add("root", new Location("You see a root.", "Root is still there..."));
            locations.Add("north1", new Location("This is north location", "Is still on north"));

            current = locations["root"];
            current.SetLink(Direction.North, locations["north1"]);

            locations["north1"].SetLink(Direction.South, locations["root"]);
            locations["north1"].AddNpc("MiB", CharacterFactory.Generate());
            locations["north1"].AddNpc("MiB2", CharacterFactory.Generate());

            locations["root"].AddItem("Token", new Item("Token", "Round token of some kind"));

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
            {
                current.visited = true;
                current = newLocation;
                Console.Write($"You ventured {direction}");
            }
            else
            {
                Console.Write("Path is blocked...");
            }
        }
    }
}
