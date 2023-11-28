using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        
        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2);
        }
        
        [Test]
        public void Does_Constructor_Initialize_Elements()
        {
            int expectedCount = 2;
            int actualCount = database.Count;
            
            Assert.NotNull(database);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Does_Count_Return_RightAmountElements()
        {
            int expectedCount = 2;
            int actualCount = database.Count;
            
            Assert.AreEqual(expectedCount, actualCount);
        }
        
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20})]
        public void Does_CreatingDatabaseWithTooManyElements_ThrowException(int[] data)
        {
            InvalidOperationException exception = 
                Assert.Throws<InvalidOperationException>(() => database = new(data));
            
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }
        
        [Test]
        public void Does_AddMethod_AddElements()
        {
            database.Add(4);
            database.Add(9);

            int[] expected = new int[] { 1, 2, 4, 9 };
            int[] actual = database.Fetch();
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Does_AddMethod_ThrowException_WhenAddingTooManyElements()
        {
            for (int i = 0; i < 14; i++)
            {
                database.Add(i);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(17));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void Does_AddMethod_IncreaseCount()
        {
            int expected = 3;
            
            database.Add(121);
            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void Does_RemoveMethod_RemoveElements()
        {
            database = new(1, 2, 3, 4, 5, 6, 7, 8 );
            
            database.Remove();
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            
            Assert.AreEqual(expected, database.Fetch());
        }

        [Test]
        public void Does_RemoveMethod_DecreaseCount()
        {
            database = new(1, 2, 3, 4, 5, 6, 7, 8);
            
            database.Remove();
            database.Remove();

            int expected = 6;
            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void Does_RemoveMethod_ThrowException_WhenDatabaseIsEmpty()
        {
            database = new();
            
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Remove());
            Assert.AreEqual("The collection is empty!", exception.Message);
        }

        [TestCase(new int[] {})]
        [TestCase(new[]{ 1, 2, 3, 4, 5, 6, 7 })]
        public void Does_FetchMethod_ReturnCorrectDatabase(int[] data)
        {
            database = new(data);
            
            Assert.AreEqual(data, database.Fetch());
        }
    }
}
