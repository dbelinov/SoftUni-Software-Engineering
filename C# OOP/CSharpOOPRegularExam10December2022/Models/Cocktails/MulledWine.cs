namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        private const double DefaultPriceOfCocktail = 13.50;
        
        public MulledWine(string cocktailName, string size) : base(cocktailName, size, DefaultPriceOfCocktail)
        {
        }
    }
}