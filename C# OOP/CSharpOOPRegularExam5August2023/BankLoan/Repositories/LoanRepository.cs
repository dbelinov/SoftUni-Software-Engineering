using System.Collections.Generic;
using System.Linq;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories;

public class LoanRepository : IRepository<ILoan>
{
    private List<ILoan> models = new();

    public IReadOnlyCollection<ILoan> Models => models.AsReadOnly();
    
    public void AddModel(ILoan loan) => models.Add(loan);

    public bool RemoveModel(ILoan loan) => models.Remove(loan);

    public ILoan FirstModel(string name)
    {
        foreach (ILoan loan in Models)
        {
            if (loan.GetType().Name == name)
            {
                return loan;
            }
        }

        return null;
    }
}