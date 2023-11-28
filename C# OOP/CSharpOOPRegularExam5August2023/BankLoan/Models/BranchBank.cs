namespace BankLoan.Models;

public class BranchBank : Bank
{
    private const int defaultCapacity = 25;
    public BranchBank(string name) : base(name, defaultCapacity)
    {
    }
}