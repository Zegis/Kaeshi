using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System;

namespace Kaeshi.Commands
{
    class EquipCommand : ICommand
    {
        private readonly IEquipment _equipment;
        private readonly EquippableItem _itemToEquip;

        public EquipCommand(IEquipment equipment, EquippableItem itemToEquip)
        {
            _equipment = equipment;
            _itemToEquip = itemToEquip;
        }

        public GameState Execute()
        {
            if (_itemToEquip == null)
            {
                Console.Write("Nothing to equip...");
            }
            else
            {
                _equipment.Equip(_itemToEquip, _itemToEquip.type);
            }

            return GameState.Play;
        }
    }
}
