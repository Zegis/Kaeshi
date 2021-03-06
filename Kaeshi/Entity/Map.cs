﻿using Keshi.Interfaces;
using Keshi.Modules;
using System;
using System.Collections.Generic;

namespace Keshi.Entity
{
    public class Map : IMap
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
            locations.Add("root", new Location("You see a root.", "Root is still there..."));
            locations.Add("north1", new Location("This is north location", "Is still on north"));

            current = locations["root"];
            current.SetLink(Direction.North, locations["north1"]);

            locations["north1"].SetLink(Direction.South, locations["root"]);
            locations["north1"].AddNpc("MiB", CharacterFactory.Generate());
            locations["north1"].AddNpc("MiB2", CharacterFactory.Generate());

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
