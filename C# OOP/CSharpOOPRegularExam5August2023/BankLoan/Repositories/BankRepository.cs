using System.Collections.Generic;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories;

public class BankRepository : IRepository<IBank>
{
    private List<IBank> models = new();

    public IReadOnlyCollection<IBank> Models => models.AsReadOnly();

    public void AddModel(IBank bank) => models.Add(bank);

    public bool RemoveModel(IBank bank) => models.Remove(bank);

    public IBank FirstModel(string name)
    {
        foreach (IBank bank in Models)
        {
            if (bank.Name == name)
            {
                return bank;
            }
        }

        return null;
    }
}