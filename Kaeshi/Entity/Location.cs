using Kaeshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kaeshi.Entity
{
    public class Location : IVisible
    {
        public bool visited { get; set; }

        private readonly string primaryDescription;

        private readonly string secondaryDescription;

        private readonly Dictionary<string, Character> npcs;

        private readonly Dictionary<string, Item> items;

        private readonly Dictionary<Direction, Location> linkedLoctions;

        public Location(string firstDescription, string secondDescription)
        {
            linkedLoctions = new Dictionary<Direction, Location>();
            npcs = new Dictionary<string, Character>(StringComparer.OrdinalIgnoreCase);
            items = new Dictionary<string, Item>(StringComparer.OrdinalIgnoreCase);
            primaryDescription = firstDescription;
            secondaryDescription = secondDescription;
            visited = false;
        }

        internal IVisible ObserveItem(string itemKey)
        {
            items.TryGetValue(itemKey, out var retVar);
            return retVar;
        }

        public string Observe()
        {
            StringBuilder fullDescription = new StringBuilder();

            if (visited)
                fullDescription.AppendLine(secondaryDescription);
            else
                fullDescription.AppendLine(primaryDescription);

            fullDescription.AppendLine("You see:");
            fullDescription.AppendJoin(',', npcs.Where(x => x.Value.IsAlive()).Select(x => x.Key));
            fullDescription.AppendLine("\nYou see bodies of:");
            fullDescription.AppendJoin(",", npcs.Where(x => !x.Value.IsAlive()).Select(x => x.Key));
            fullDescription.AppendLine("\nOn floor lies:");
            fullDescription.AppendJoin(",", items.Select(x => x.Key));

            return fullDescription.ToString();
        }

        internal Item GetItem(string itemKey)
        {
            if(items.TryGetValue(itemKey, out var retVar))
                items.Remove(itemKey);
            return retVar;
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

        public virtual void AddItem(string itemName, Item itemToAdd)
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
