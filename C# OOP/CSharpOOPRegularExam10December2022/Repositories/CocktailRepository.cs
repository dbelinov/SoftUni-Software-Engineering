using System.Collections.Generic;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> models = new List<ICocktail>();
        public IReadOnlyCollection<ICocktail> Models => models.AsReadOnly();

        public void AddModel(ICocktail cocktail) => models.Add(cocktail);
    }
}