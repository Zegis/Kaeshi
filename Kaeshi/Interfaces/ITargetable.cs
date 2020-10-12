namespace Keshi.Interfaces
{
    public interface ITargetable
    {
        bool isHit(int hitValue);
        public void Attack(int damage);
    }
}
