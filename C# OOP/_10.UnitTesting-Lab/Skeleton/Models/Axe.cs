using System;
using Skeleton.Models.Interfaces;

// Axe durability drop with 5 
namespace Skeleton.Models;

public class Axe : IWeapon
{
    private int attackPoints;
    private int durabilityPoints;

    public Axe(int attack, int durability)
    {
        attackPoints = attack;
        durabilityPoints = durability;
    }

    public int AttackPoints => attackPoints;

    public int DurabilityPoints => durabilityPoints;

    public void Attack(ITarget target)
    {
        if (durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.attackPoints);
        durabilityPoints -= 1;
    }
}