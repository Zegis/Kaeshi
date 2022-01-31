using Kaeshi.Entity;

namespace Kaeshi.Interfaces
{
    interface IEquipment
    {
        void Equip(EquippableItem item, EquippableType type);
        void Unequip(EquippableType type);
    }
}
