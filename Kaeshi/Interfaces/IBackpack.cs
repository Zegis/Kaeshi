﻿using Kaeshi.Entity;

namespace Kaeshi.Interfaces
{
    public interface IBackpack
    {
        void PutInBackpack(Item item);
        void RemoveFromBackpack(Item item);
        string DisplayBackpack();
        IUsable GetUsableItem(string name);
    }
}