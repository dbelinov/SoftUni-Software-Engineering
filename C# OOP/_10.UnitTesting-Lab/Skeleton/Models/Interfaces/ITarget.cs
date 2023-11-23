namespace Skeleton.Models.Interfaces;

public interface ITarget
{
    int Health { get; }
    void TakeAttack(int attackPoints);
    int GiveExperience();
    bool IsDead();
}