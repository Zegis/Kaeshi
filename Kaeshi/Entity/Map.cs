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

            var dummy = new Character(1, 1, 1);
            dummy.PutInBackpack(new Item("Dummy pieces", "Pieces of wooden dummy"));

            locations["north1"].SetLink(Direction.South, locations["root"]);
            locations["north1"].AddNpc("MiB", CharacterFactory.Generate());
            locations["north1"].AddNpc("MiB2", CharacterFactory.Generate());

            locations["root"].AddItem("Token", new Item("Token", "Round token of some kind"));
            locations["root"].AddItem("AidKit", new UsableItem("AidKit","First aid kit, heals small amount of health",2, EffectsLibrary.Get("heal")));
            locations["root"].AddItem("Armor", new EquippableItem("Armor", "Standard buletproof vest", 2, EquippableType.Armor));
            locations["root"].AddNpc("Dummy", dummy);

            return locations;
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
