using Kaeshi.Entity;
using Kaeshi.Interfaces;

namespace Kaeshi.Commands
{
    public class UnequipCommand : ICommand
    {
        private readonly IEquipment _equipment;
        private readonly EquippableType _slot;

        public UnequipCommand(IEquipment equipment, EquippableType slotToUnequip)
        {
            _equipment = equipment;
            _slot = slotToUnequip;
        }

        public GameState Execute()
        {
            _equipment.Unequip(_slot);

            return GameState.Play;
        }
    }
}
