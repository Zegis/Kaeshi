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

        private void LoadLocations()
        {
            var locations = new Dictionary<string, Location>();
            locations.Add("entry", new Location("You see a root.", "Root is still there..."));
            locations.Add("toilets_1", new Location("", ""));
            locations.Add("corridor_1", new Location("", ""));
            locations.Add("dining_1", new Location("", ""));
            locations.Add("dining_2", new Location("", ""));
            locations.Add("corridor_2", new Location("", ""));
            locations.Add("corridor_3", new Location("", ""));
            locations.Add("corridor_4", new Location("", ""));
            locations.Add("meeting_1", new Location("", ""));
            locations.Add("elevators", new Location("", ""));

            current = locations["entry"];
            locations["entry"].SetLink(Direction.South, locations["corridor_1"]);

            locations["corridor_1"].SetLink(Direction.North, locations["entry"]);
            locations["corridor_1"].SetLink(Direction.West, locations["toilets_1"]);
            locations["corridor_1"].SetLink(Direction.East, locations["dining_1"]);
            locations["corridor_1"].SetLink(Direction.South, locations["corridor_2"]);

            locations["toilets_1"].SetLink(Direction.East, locations["corridor_1"]);

            locations["dining_1"].SetLink(Direction.West, locations["corridor_1"]);
            locations["dining_1"].SetLink(Direction.South, locations["dining_2"]);

            locations["dining_2"].SetLink(Direction.North, locations["dining_1"]);
            locations["dining_2"].SetLink(Direction.East, locations["corridor_2"]);

            locations["corridor_2"].SetLink(Direction.North, locations["corridor_1"]);
            locations["corridor_2"].SetLink(Direction.West, locations["dining_2"]);
            locations["corridor_2"].SetLink(Direction.South, locations["meeting_1"]);
            locations["corridor_2"].SetLink(Direction.East, locations["corridor_3"]);

            locations["meeting_1"].SetLink(Direction.North, locations["corridor_2"]);

            locations["corridor_3"].SetLink(Direction.West, locations["corridor_2"]);
            locations["corridor_3"].SetLink(Direction.South, locations["corridor_4"]);

            locations["corridor_4"].SetLink(Direction.North, locations["corridor_3"]);
            locations["corridor_4"].SetLink(Direction.South, locations["elevators"]);
        }

        public virtual Location GetCurrentLocation()
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
