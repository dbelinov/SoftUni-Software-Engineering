namespace BankLoan.Models;

public class MortgageLoan : Loan
{
    private const int defaultInterestRate = 3;
    private const int defaultAmount = 50000;
    
    public MortgageLoan() : base(defaultInterestRate, defaultAmount)
    {
    }
}