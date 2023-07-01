using System;
using System.Collections.Generic;
using System.Linq;

/*
SoftUni -> AA12345
SoftUni -> BB12345
Microsoft -> CC12345
HP -> BB12345
End

SoftUni -> AA12345
SoftUni -> CC12344
Lenovo -> XX23456
SoftUni -> AA12345
Movement -> DD11111
End
*/

namespace _07.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" -> ");
                string companyName = tokens[0];
                string employeeId = tokens[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }

                if (!companies[companyName].Any(id => id == employeeId))
                {
                    companies[companyName].Add(employeeId);
                }
            }

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);
                foreach (var value in company.Value)
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}