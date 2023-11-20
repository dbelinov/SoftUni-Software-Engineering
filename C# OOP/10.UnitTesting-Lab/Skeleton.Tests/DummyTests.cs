using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int DeadDummyHealth = 0;
        private const int DefaultAxeAttack = 10;
        private const int DefaultAxeDurability = 10;
        private const int DefaultDummyHealth = 20;
        private const int DefaultDummyExperience = 10;

        [Test]
        public void Does_Constructor_AssignValues_WhenClassCalled()
        {
            Dummy dummy = new(DeadDummyHealth, DefaultDummyExperience);

            Assert.AreEqual(DeadDummyHealth, dummy.Health, "Dummy health should be initialized");
            Assert.AreEqual(DefaultDummyExperience, dummy.GiveExperience(), "Dummy experience should be initialized");
        }

        [Test]
        public void Does_DummyLoseHealth_WhenAttacked()
        {
            Dummy dummy = new(DefaultDummyHealth, DefaultDummyExperience);
            Axe axe = new(DefaultAxeAttack, DefaultAxeDurability);

            axe.Attack(dummy);

            Assert.AreEqual(10, dummy.Health, "Dummy has to lose health");
        }

        [Test]
        public void Does_DeadDummy_ThrowError_WhenAttacked()
        {
            Dummy dummy = new(DeadDummyHealth, DefaultDummyExperience);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(DefaultAxeAttack), "Can't attack dead dummy");
        }

        [Test]
        public void IsExceptionThrown_WhenAliveDummy_TriesToGiveXp()
        {
            Dummy dummy = new(DefaultDummyHealth, DefaultDummyExperience);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead");
        }

        [Test]
        public void Does_IsDead_ReturnTrue_When_DummyDead()
        {
            Dummy dummy = new Dummy(DeadDummyHealth, DefaultDummyExperience);

            Assert.IsTrue(dummy.IsDead(), "Target should be dead");
        }
    }
}