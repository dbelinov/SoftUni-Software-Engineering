using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models;

public abstract class Bank : IBank
{
    private string name;
    private List<ILoan> loans;
    private List<IClient> clients;

    protected Bank(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        loans = new List<ILoan>();
        clients = new List<IClient>();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
            }

            name = value;
        }
    }

    public int Capacity { get; }
    public IReadOnlyCollection<ILoan> Loans => loans.AsReadOnly();
    public IReadOnlyCollection<IClient> Clients => clients.AsReadOnly();

    public double SumRates() => Loans.Sum(loan => loan.InterestRate);

    public void AddClient(IClient Client)
    {
        if (Clients.Count == Capacity)
        {
            throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
        }

        clients.Add(Client);
    }

    public void RemoveClient(IClient Client) => clients.Remove(Client);

    public void AddLoan(ILoan loan) => loans.Add(loan);

    public string GetStatistics()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Name: {Name}, Type: {GetType().Name}");
        if (clients.Count > 0)
        {
            sb.AppendLine($"Clients: {string.Join(", ", clients.Select(c => c.Name))}");
        }
        else
        {
            sb.AppendLine("Clients: none");
        }

        sb.AppendLine($"Loans: {Loans.Count}, Sum of Rates: {SumRates()}");

        return sb.ToString().Trim();
    }
}