using System.Collections.Generic;
using System.Linq;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories;

public class TeamRepository : IRepository<ITeam>
{
    private List<ITeam> models = new();

    public IReadOnlyCollection<ITeam> Models => models.AsReadOnly();

    public void AddModel(ITeam model) => models.Add(model);

    public bool RemoveModel(string name)
    {
        ITeam team = GetModel(name);
        return models.Remove(team);
    }

    public bool ExistsModel(string name) => models.Any(m => m.Name == name);

    public ITeam GetModel(string name) => models.FirstOrDefault(m => m.Name == name);
}