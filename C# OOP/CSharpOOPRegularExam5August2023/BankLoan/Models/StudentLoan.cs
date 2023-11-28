namespace BankLoan.Models;

public class StudentLoan : Loan
{
    private const int defaultInterestRate = 1;
    private const int defaultAmount = 10000;
    
    public StudentLoan() : base(defaultInterestRate, defaultAmount)
    {
    }
}