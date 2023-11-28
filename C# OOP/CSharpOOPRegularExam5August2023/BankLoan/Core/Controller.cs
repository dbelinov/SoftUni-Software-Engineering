using System;
using System.Linq;
using System.Text;
using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;

namespace BankLoan.Core;

public class Controller : IController
{
    private LoanRepository loans = new();
    private BankRepository banks = new();
    
    public string AddBank(string bankTypeName, string name)
    {
        IBank bank;
        if (bankTypeName == "BranchBank")
        {
            bank = new BranchBank(name);
        }
        else if (bankTypeName == "CentralBank")
        {
            bank = new CentralBank(name);
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
        }
        
        banks.AddModel(bank);
        return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
    }

    public string AddLoan(string loanTypeName)
    {
        ILoan loan;
        if (loanTypeName == "MortgageLoan")
        {
            loan = new MortgageLoan();
        }
        else if (loanTypeName == "StudentLoan")
        {
            loan = new StudentLoan();
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
        }

        loans.AddModel(loan);
        return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
    }

    public string ReturnLoan(string bankName, string loanTypeName)
    {
        ILoan loan;
        if (loanTypeName == "MortgageLoan")
        {
            loan = new MortgageLoan();
        }
        else
        {
            loan = new StudentLoan();
        }
        
        
        if (!loans.RemoveModel(loans.FirstModel(loanTypeName)))
        {
            throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
        }
        banks.FirstModel(bankName).AddLoan(loan);
        return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
    }

    public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
    {
        Client client;
        if (clientTypeName == "Adult")
        {
            client = new Adult(clientName, id, income);
        }
        else if (clientTypeName == "Student")
        {
            client = new Student(clientName, id, income);
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
        }

        if (clientTypeName == "Adult" && banks.FirstModel(bankName).GetType().Name == "BranchBank"
            || clientTypeName == "Student" && banks.FirstModel(bankName).GetType().Name == "CentralBank")
        {
            return OutputMessages.UnsuitableBank;
        }

        banks.FirstModel(bankName).AddClient(client);
        return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
    }
    
    public string FinalCalculation(string bankName)
    {
        decimal funds = (decimal) banks.FirstModel(bankName).Loans.Sum(l => l.Amount)
         + (decimal) banks.FirstModel(bankName).Clients.Sum(c => c.Income);
        
        return string.Format(OutputMessages.BankFundsCalculated, bankName, $"{funds:f2}");
    }
        

    public string Statistics()
    {
        StringBuilder sb = new StringBuilder();
        foreach (IBank bank in banks.Models)
        {
            sb.AppendLine(bank.GetStatistics());
        }

        return sb.ToString().Trim();
    }
}