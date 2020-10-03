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

        private Dictionary<Direction, Location> linkedLoctions;

        public Location(string firstDescription, string secondDescription)
        {
            linkedLoctions = new Dictionary<Direction, Location>();
            npcs = new Dictionary<string, Character>();
            primaryDescription = firstDescription;
            secondaryDescription = secondDescription;
            visited = false;
        }

        public string Observe()
        {
            if (visited)
                return secondaryDescription + " " + String.Join("", npcs.Keys);
            else
                return primaryDescription + " " + String.Join("", npcs.Keys);
            
        }

        public IVisible ObserveNpc(string NpcName)
        {
            npcs.TryGetValue(NpcName, out var retVar);
            return retVar;
        }

        public ITargetable TargetNpc(string NpcName)
        {
            npcs.TryGetValue(NpcName, out var retVal);
            return retVal;
        }

        public void AddNpc(string NpcName ,Character NpcToAdd)
        {
            npcs[NpcName] = NpcToAdd;
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
