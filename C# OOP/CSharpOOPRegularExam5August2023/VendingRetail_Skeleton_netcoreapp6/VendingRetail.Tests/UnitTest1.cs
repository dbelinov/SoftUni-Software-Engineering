using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat coffeeMat;
        
        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(2000, 2);
        }

        [Test]
        public void Does_ConstructorInitializeAllObjectsCorrectly()
        {
            int expectedWaterCapacity = 2000;
            Assert.AreEqual(expectedWaterCapacity, coffeeMat.WaterCapacity);

            int expectedButtonCount = 2;
            Assert.AreEqual(expectedButtonCount, coffeeMat.ButtonsCount);

            int expectedIncome = 0;
            Assert.AreEqual(expectedIncome, coffeeMat.Income);
            
            Assert.IsNotNull(coffeeMat);
        }

        [Test]
        public void Does_FillWaterTankMethod_ReturnCorrectString()
        {
            string expectedString = "Water tank is filled with 2000ml";
            Assert.AreEqual(expectedString, coffeeMat.FillWaterTank());
        }

        [Test]
        public void Does_FillWaterTankMethod_ReturnCorrectStringWhenTankIsFull()
        {
            string expected = "Water tank is already full!";
            coffeeMat.FillWaterTank();
            Assert.AreEqual(expected, coffeeMat.FillWaterTank());
        }

        [Test]
        public void Does_AddDrinkMethod_ReturnTrue_WhenDrinkAdded()
        {
            Assert.IsTrue(coffeeMat.AddDrink("Cola", 1.60));
        }

        [Test]
        public void Does_AddDrinkMethod_ReturnFalse_WhenButtonCountIsFull()
        {
            coffeeMat.AddDrink("Cola", 1.50);
            coffeeMat.AddDrink("Fanta", 2.00);
            Assert.IsFalse(coffeeMat.AddDrink("Sprite", 2.20));
        }

        [Test]
        public void Does_AddDrinkMethod_ReturnFalse_WhenDrinkAlreadyExists()
        {
            coffeeMat.AddDrink("Cola", 1.50);
            Assert.IsFalse(coffeeMat.AddDrink("Cola", 1.50));
        }

        [Test]
        public void Does_BuyDrinkMethod_ReturnCorrectString()
        {
            double price = 2.60;
            string expectedString = $"Your bill is {price:f2}$";
            coffeeMat.AddDrink("Cola", price);
            coffeeMat.FillWaterTank();
            Assert.AreEqual(expectedString, coffeeMat.BuyDrink("Cola"));
        }

        [Test]
        public void Does_BuyDrinkMethod_ReturnCorrectString_WhenWaterTankIsLessThan80()
        {
            coffeeMat = new CoffeeMat(200, 2);
            
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("Cola", 2.60);
            coffeeMat.AddDrink("Sprite", 2.00);

            string expected = "CoffeeMat is out of water!";
            coffeeMat.BuyDrink("Sprite");
            coffeeMat.BuyDrink("Sprite");
            
            Assert.AreEqual(expected, coffeeMat.BuyDrink("Cola"));
        }

        [Test]
        public void Does_BuyDrinkMethod_ReturnCorrectString_WhenDrinkNotAvailable()
        {
            string expected = "Cola is not available!";

            coffeeMat.FillWaterTank();
            
            Assert.AreEqual(expected, coffeeMat.BuyDrink("Cola"));
        }

        [Test]
        public void Does_IncomeIncrease_WhenUsingBuyDrinkMethod()
        {
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("Cola", 2.60);
            coffeeMat.BuyDrink("Cola");

            double expected = 2.60;
            
            Assert.AreEqual(expected, coffeeMat.Income);
        }

        [Test]
        public void Does_CollectIncomeMethod_ReturnCorrectIncome()
        {
            double expected = 7.50;

            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("Cola", 2.50);
            coffeeMat.BuyDrink("Cola");
            coffeeMat.BuyDrink("Cola");
            coffeeMat.BuyDrink("Cola");
            
            Assert.AreEqual(expected, coffeeMat.CollectIncome());
        }

        [Test]
        public void Does_CollectIncomeMethod_MakeIncomeProperty0()
        {
            double expectedIncome = 7.50;
            double expected = 0;

            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("Cola", 2.50);
            coffeeMat.BuyDrink("Cola");
            coffeeMat.BuyDrink("Cola");
            coffeeMat.BuyDrink("Cola");
            
            Assert.AreEqual(expectedIncome, coffeeMat.CollectIncome());
            Assert.AreEqual(expected, coffeeMat.Income);
        }
    }
}