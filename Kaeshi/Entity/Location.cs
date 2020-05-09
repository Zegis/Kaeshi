using Keshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Entity
{
    public class Location : IVisible
    {
        private bool firstVisit = true;

        private string primaryDescription = "1st visit! :O";

        private string secondaryDescription = "So much changed since last visit!";

        public string Observe()
        {
            if (firstVisit)
                return primaryDescription;
            else
                return secondaryDescription;
        }
    }
}
