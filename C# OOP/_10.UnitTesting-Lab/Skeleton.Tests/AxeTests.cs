using System;
using NUnit.Framework;
using Skeleton.Models;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int DefaultAxeAttack = 10;
        private const int DefaultAxeDurability = 10;

        [Test]
        public void Does_Constructor_AssignValues_WhenClassCalled()
        {
            Axe axe = new Axe(DefaultAxeAttack, DefaultAxeDurability);

            Assert.AreEqual(DefaultAxeAttack, axe.AttackPoints, "Axe attack should be initialized");
            Assert.AreEqual(DefaultAxeDurability, axe.DurabilityPoints, "Axe durability should be initialized");
        }

        [Test]
        public void Does_Weapon_LoseDurability_AfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void Does_Weapon_AttackWhen_Broken()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");
        }
    }
}