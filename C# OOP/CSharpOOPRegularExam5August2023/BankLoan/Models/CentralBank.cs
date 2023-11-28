namespace BankLoan.Models;

public class CentralBank : Bank
{
    private const int defaultCapacity = 50;
    
    public CentralBank(string name) : base(name, defaultCapacity)
    {
    }
}