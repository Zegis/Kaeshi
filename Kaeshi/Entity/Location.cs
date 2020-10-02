using Keshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Entity
{
    public class Location : IVisible
    {
        public bool visited;

        private string primaryDescription;

        private string secondaryDescription;

        private Dictionary<Direction, Location> linkedLoctions = new Dictionary<Direction, Location>();

        public Location(string firstDescription, string secondDescription)
        {
            primaryDescription = firstDescription;
            secondaryDescription = secondDescription;
            visited = false;
        }

        public string Observe()
        {
            if (visited)
                return secondaryDescription;
            else
                return primaryDescription;
            
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
