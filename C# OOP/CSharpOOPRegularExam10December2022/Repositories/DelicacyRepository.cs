using System.Collections.Generic;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> models = new List<IDelicacy>();
        public IReadOnlyCollection<IDelicacy> Models => models.AsReadOnly();

        public void AddModel(IDelicacy delicacy) => models.Add(delicacy);
    }
}