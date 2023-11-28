using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            database = new(
                new Person(1, "vikito"),
                new Person(2, "Dimitrichkoto"),
                new Person(3, "Ginko"),
                new Person(4, "Toshko"));
        }

        [Test]
        public void Does_Constructor_InitializePeopleAndChangeCountCorrectly()
        {
            int expected = 4;
            
            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void Does_Constructor_ThrowException_WhenAddingTooManyPeople()
        {
            Person[] people =
            {
                new Person(1, "vikito"),
                new Person(2, "Dimitrichkoto"),
                new Person(3, "Ginko"),
                new Person(4, "Pencho"),
                new Person(5, "Toshko"),
                new Person(6, "Pesho"),
                new Person(7, "Ivan"),
                new Person(8, "Gosho"),
                new Person(9, "Bombo"),
                new Person(10, "Svetlio"),
                new Person(11, "Niko"),
                new Person(12, "Paul"),
                new Person(13, "Jorko"),
                new Person(14, "NqmamIme"),
                new Person(15, "KakSme"),
                new Person(16, "KoPraim"),
                new Person(17, "KoStaaa")
            };

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => database = new Database(people));
            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
        }
    }
}