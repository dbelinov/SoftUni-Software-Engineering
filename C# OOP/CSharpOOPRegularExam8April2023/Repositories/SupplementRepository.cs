using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories;

public class SupplementRepository : IRepository<ISupplement>
{
    private List<ISupplement> supplements = new List<ISupplement>();

    public IReadOnlyCollection<ISupplement> Models() => supplements.AsReadOnly();

    public void AddNew(ISupplement supplement) => supplements.Add(supplement);

    public bool RemoveByName(string typeName)
    {
        ISupplement supplement = supplements.FirstOrDefault(s => s.GetType().Name == typeName);
        if (supplement != null)
        {
            supplements.Remove(supplement);
            return true;
        }

        return false;
    }

    public ISupplement FindByStandard(int interfaceStandard) 
        => supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
}