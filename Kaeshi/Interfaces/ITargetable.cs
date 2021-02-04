namespace Keshi.Interfaces
{
    public interface ITargetable
    {
        bool IsHit(int hitValue);

        bool IsAlive();
        public void Attack(int damage);
    }
}
