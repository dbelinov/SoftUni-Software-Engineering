﻿using BankLoan.Core.Contracts;
using BankLoan.IO.Contracts;
using BankLoan.IO;
using System;
using System.Collections.Generic;
using System.Text;

/*
AddBank BranchBank DSKBank
AddBank CentralBank Unicredit
AddBank CentralBank Fibank
AddLoan StudentLoan
AddLoan MortgageLoan
AddLoan MortgageLoan
ReturnLoan DSKBank StudentLoan
ReturnLoan Unicredit StudentLoan
ReturnLoan DSKBank MortgageLoan
ReturnLoan Fibank MortgageLoan
AddClient DSKBank Student Sarah 10A2AFBBAG 5421,5
AddClient DSKBank Student Tom 54AABAG75 2341,1
AddClient Fibank Adult Peter 6GSFAAZZ12 125054
FinalCalculation DSKBank
Statistics
End

AddBank BranchBank DSKBank
AddBank CentralBank Fibank
AddLoan StudentLoan
AddLoan MortgageLoan
AddLoan MortgageLoan
ReturnLoan DSKBank StudentLoan
ReturnLoan Fibank StudentLoan
ReturnLoan Fibank MortgageLoan
AddClient Fibank Student Maria 54TAF433 346,7
AddClient Fibank Adult Peter 65GTTHA134 5643,1
FinalCalculation Fibank
Statistics
End
*/

namespace BankLoan.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;
        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "End")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddBank")
                    {
                        string bankTypeName = input[1];
                        string name = input[2];

                        result = controller.AddBank(bankTypeName, name);
                    }
                    else if (input[0] == "AddLoan")
                    {
                        string loanTypeName = input[1];

                        result = controller.AddLoan(loanTypeName);
                    }
                    else if (input[0] == "ReturnLoan")
                    {
                        string bankName = input[1];
                        string loanTypeName = input[2];

                        result = controller.ReturnLoan(bankName, loanTypeName);
                    }
                    else if (input[0] == "AddClient")
                    {
                        string bankName = input[1];
                        string clientTypeName = input[2];
                        string clientName = input[3];
                        string id = input[4];
                        double income = double.Parse(input[5]);

                        result = controller.AddClient(bankName, clientTypeName, clientName, id, income);
                    }
                    else if (input[0] == "FinalCalculation")
                    {
                        string bankName = input[1];

                        result = controller.FinalCalculation(bankName);
                    }
                    else if (input[0] == "Statistics")
                    {
                        result = controller.Statistics();
                    }
                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
