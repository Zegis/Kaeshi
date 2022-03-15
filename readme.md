.NET Core minimalistic console text adventure.

Current map is proof of work for implemented mechanics:
- Moving around
- Fighting with monsters
- Picking up items
- Using items
- Equipping and taking off armor and weapons.

Below is the list of all commands currently implemented in game.
Those are case insensitive.

|Command | Description | Example |
|----|---- |----|
| look [object] | Prints description for given object. <br/> There are 2 special "objects" that are always there to look at:<br/> - _around_ for current location description. <br/> - _yourself_ for description of your character   | look around |
| north <br/> east <br/> south <br/> west | Moves main character in given direction | west
| take [object] | Puts the object into character backpack. <br/> _Object need to be in current location_ | take token |
| attack [npc] | Starts battle with a given npc character. <br/> __Npc will retaliate if able.__ | attack mib|
| open | Displays the content of main character backpack | open |
| use [item] | Uses item if possible. <br/> _Item need to be in character backpack. <br/> All items have set count of uses_| use aidkit |
| equip [item] | Equips selected item as weapon or armor. <br/> _item must be in character backpack_ | equip armor |
| unequip [slot] | Takes off item from given slot. <br/> Currently there are only 2 slots: __armor__ and __weapon__. | unequip armor |
| exit | Turns off the game | exit |