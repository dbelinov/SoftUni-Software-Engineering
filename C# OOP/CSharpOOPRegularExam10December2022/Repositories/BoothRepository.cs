using System.Collections.Generic;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> models = new List<IBooth>();
        
        public IReadOnlyCollection<IBooth> Models => models.AsReadOnly();

        public void AddModel(IBooth booth) => models.Add(booth);
    }
}