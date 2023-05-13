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
            var locations = new Dictionary<string, Location>()
            {
                {"entry", 
                    new Location(
                        "You entered the building through revolving glass door. You're in the lobby. " +
                        "\r\nOn the right there is receptionist, he don't pay attention to you. " +
                        "\r\nYou can go South passing the security gates to enter a long corridor."
                        ,"Lobby didn't change much since your last visit. Maybe the receptionist is looking more bored than before.\r\n" +
                        "You sigh, you know you can't left the building without finishing the mission.\r\n" +
                        "Only way is South deeper into the building.") 
                },
                {"toilets_1", 
                    new Location("A small lavatory with single cabin, and sink with mirror hanging above. " +
                    "\r\nNext to the mirror is poster reminding how to properly wash hands." +
                    "\r\nOn East wall there is corridor door."
                    , "Small lavatory. You can see someone used it recently. It doesn't smell good here." +
                    "\r\nOn East wall there's a door leading to the corridor.") },
                {"corridor_1",
                    new Location("You passed the security gates, walked a few steps looking at company motivational posters. You stopped at pair of doors." +
                    "\r\nIf you go North you'll go back to the entrance." +
                    "\r\nYou look to the West and see doors with a pictogram of a person. Looks like enterance to lavatory." +
                    "\r\nOn the oposite East wall there is yet another door made of glass. You can see tables and chairs and some people eating." +
                    "\r\nYou can continue moving South along the corridor."
                    , "You returned to the crossroads decorated with motivational posters." +
                    "\r\nIf you turn back South you'll return deeper into the building." +
                    "\r\nTo the East there's a dining room." +
                    "\r\nOpposite, on the West wall you see lavatory door." +
                    "\r\nKeep going North if you want to left the building.") },
                {"dining_1", 
                    new Location("Main area of Dining room with a lot of tables, and small water dispenser. It's crowded with people minding their own businesses." +
                    "\r\nSouth is a kitchen area." +
                    "\r\nWest you can see the corridor through glass door."
                    , "Dining room with tables. Seems like there's no one here, just a water dispenser and a lot of tables." +
                    "\r\nSouth is kitchen area." +
                    "\r\nWest are doors leading to the corridor.") },
                {"dining_2", 
                    new Location("Kitchen area of the dining room. There's refigerator, coffee machine and pair of microwaves. " +
                    "\r\nIt smells nice, as if someone just finished warming something good." +
                    "\r\nIf you go North you'll reach the main part of dining room." +
                    "\r\nTo the West past glass door there's a corridor."
                    , "Kitchen area of the dining room. There's a plate heating up in microwave next to the refigerator." +
                    "\r\nNorth is main part of dining room." +
                    "\r\nOn West wall there is a glass door leading to corridor.") },
                {"corridor_2", 
                    new Location("Another dozen of steps, and another set of doors. One of walls is made of glass, and you can see a kitchen through it." +
                    "\r\nCorridor turns West." +
                    "\r\nBefore your eyes on South wall there's a set of large wooden doors with \"Plains\" sign on it. Perhaps a meeting room?" +
                    "\r\nThe glass wall to your East contain a door to the kitchen area." +
                    "\r\nTo the North you see familiar corridor crossroads with lavatory and dining."
                    , "It's the good old corridor turning. On the wall there's a photo of smilling employee with some motivational motto about being part of one big family." +
                    "\r\nThere's meeting room \"Plains' to the South." +
                    "\r\nGlass door on the East side leading to the kitchen." +
                    "\r\nGoing North you'll go back to dining - lavatory crossroads." +
                    "\r\nWest is corridor leading to the elevators.") },
                {"corridor_3", 
                    new Location("Yet another turn. It's quite calming after two crossroads. " +
                    "\r\nTo the south you see corridor leading to the elevators." +
                    "\r\nYou can turn East to return to the corridor crossroads. Further along you see glass, kitchen doors"
                    , "Plain turning. Nothing to see here besides some motivational posters." +
                    "\r\nTo the south there's part of corridor leading to the elevators." +
                    "\r\nYou can turn East to return to kitchen - meeting room crossroads.") },
                {"corridor_4", 
                    new Location("Straight corridor with some potted plants, you can see the Elevators at the end. Finally." +
                    "\r\nYou can see elevators further to the South." +
                    "\r\nTo the North there's a plain turn with motivational posters."
                    , "Corridor with some plants." +
                    "\r\nYou can see elevators further to the South." +
                    "\r\nTo the North there's a plain turn with motivational posters.") },
                {"meeting_1", 
                    new Location("A small office with single table and two chairs. Looks like a room designated for one to one meetings between employees." +
                    "\r\nThere's only one exit on the North wall."
                    , "An one on one meeting room, with table and set of chairs. They doesn't look comfortable." +
                    "\r\nGoing North you'll go back to the corridor.") },
                {"elevators",
                          new Location("Set of 3 elevators, one of them is visibly larger, probably for making deliveries with office supplies." +
                          "\r\nThere's a card reader next to each elevator. Looks like you can't use any without security key." +
                          "\r\nYou can go back North to the long corridor leading to various places on this floor."
                          , "Still the same 3 elevators, with card readers." +
                          "\r\nTo the North is a long corridor you can take to reach rest of the floor.") }
            };

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
            locations["dining_2"].SetLink(Direction.West, locations["corridor_2"]);

            locations["corridor_2"].SetLink(Direction.North, locations["corridor_1"]);
            locations["corridor_2"].SetLink(Direction.East, locations["dining_2"]);
            locations["corridor_2"].SetLink(Direction.South, locations["meeting_1"]);
            locations["corridor_2"].SetLink(Direction.West, locations["corridor_3"]);

            locations["meeting_1"].SetLink(Direction.North, locations["corridor_2"]);

            locations["corridor_3"].SetLink(Direction.East, locations["corridor_2"]);
            locations["corridor_3"].SetLink(Direction.South, locations["corridor_4"]);

            locations["corridor_4"].SetLink(Direction.North, locations["corridor_3"]);
            locations["corridor_4"].SetLink(Direction.South, locations["elevators"]);

            locations["elevators"].SetLink(Direction.North, locations["corridor_4"]);
            locations["elevators"].final = true;
        }

        public virtual Location GetCurrentLocation()
        {
            return current;
        }

        public bool Go(Direction direction)
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

            return current.final;
        }
    }
}
