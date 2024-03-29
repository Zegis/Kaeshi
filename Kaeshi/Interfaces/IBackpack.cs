﻿using Kaeshi.Entity;

namespace Kaeshi.Interfaces
{
    public interface IBackpack
    {
        void PutInBackpack(Item item);
        void RemoveFromBackpack(Item item);
        string DisplayBackpack();
        UsableItem GetUsableItem(string itemName);

        EquippableItem GetEquippableItem(string itemName);
    }
}