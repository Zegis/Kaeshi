using Keshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Entity
{
    public class Location : IVisible
    {
        private bool visited = true;

        private string primaryDescription = "1st visit! :O";

        private string secondaryDescription = "So much changed since last visit!";

        private Dictionary<Direction, Location> linkedLoctions = new Dictionary<Direction, Location>();

        public string Observe()
        {
            if (visited)
                return primaryDescription;
            else
                return secondaryDescription;
        }

        public void SetLink(Direction direction, Location locationToLink)
        {
            linkedLoctions[direction] = locationToLink;
        }

        public Location GetLink(Direction direction)
        {
            return linkedLoctions[direction];
        }
    }
}
