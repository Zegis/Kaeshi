using Keshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keshi.Entity
{
    public class Location : IVisible
    {
        public bool visited;

        private string primaryDescription;

        private string secondaryDescription;

        private Dictionary<string, Character> npcs;

        private Dictionary<string, Item> items;

        private Dictionary<Direction, Location> linkedLoctions;

        public Location(string firstDescription, string secondDescription)
        {
            linkedLoctions = new Dictionary<Direction, Location>();
            npcs = new Dictionary<string, Character>(StringComparer.OrdinalIgnoreCase);
            items = new Dictionary<string, Item>(StringComparer.OrdinalIgnoreCase);
            primaryDescription = firstDescription;
            secondaryDescription = secondDescription;
            visited = false;
        }

        public string Observe()
        {
            StringBuilder fullDescription = new StringBuilder();

            if (visited)
                fullDescription.AppendLine(secondaryDescription);
            else
                fullDescription.AppendLine(primaryDescription);

            fullDescription.AppendLine("You see:");
            fullDescription.AppendJoin(',', npcs.Where(x => x.Value.IsAlive() == true).Select(x => x.Key));
            fullDescription.AppendLine("\nYou see bodies of:");
            fullDescription.AppendJoin(",", npcs.Where(x => x.Value.IsAlive() == false).Select(x => x.Key));
            fullDescription.AppendLine("\nOn floor lies:");
            fullDescription.AppendJoin(",", items.Select(x => x.Key));

            return fullDescription.ToString();
        }

        public IVisible ObserveNpc(string NpcName)
        {
            npcs.TryGetValue(NpcName, out var retVar);
            return retVar;
        }

        public IBattler TargetNpc(string NpcName)
        {
            npcs.TryGetValue(NpcName, out var retVal);
            return retVal;
        }

        public void AddNpc(string NpcName ,Character NpcToAdd)
        {
            npcs[NpcName] = NpcToAdd;
        }

        public void AddItem(string itemName, Item itemToAdd)
        {
            items[itemName] = itemToAdd;
        }

        public void SetLink(Direction direction, Location locationToLink)
        {
            linkedLoctions[direction] = locationToLink;
        }

        public Location GetLink(Direction direction)
        {
            linkedLoctions.TryGetValue(direction, out var retVal);
            return retVal;
        }
    }
}
