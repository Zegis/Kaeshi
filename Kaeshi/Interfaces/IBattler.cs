﻿namespace Kaeshi.Interfaces
{
    public partial interface IBattler
    {
        bool IsHit(int hitValue);

        bool IsAlive();
        public void Injure(int damage);

        int GetHitValue();

        int GetDamage();
    }
}
