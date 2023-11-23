namespace Skeleton.Models.Interfaces;

public interface IWeapon
{
    int AttackPoints { get; }
    int DurabilityPoints { get; }
    public void Attack(ITarget target);
}