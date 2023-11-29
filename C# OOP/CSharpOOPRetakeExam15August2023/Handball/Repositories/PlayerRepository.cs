using System.Collections.Generic;
using System.Linq;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories;

public class PlayerRepository : IRepository<IPlayer>
{
    private List<IPlayer> players = new();

    public IReadOnlyCollection<IPlayer> Models => players.AsReadOnly();

    public void AddModel(IPlayer model) => players.Add(model);

    public bool RemoveModel(string name)
    {
        IPlayer player = GetModel(name);

        return players.Remove(player);
    }

    public bool ExistsModel(string name) => players.Any(p => p.Name == name);

    public IPlayer GetModel(string name) => players.FirstOrDefault(m => m.Name == name);
}