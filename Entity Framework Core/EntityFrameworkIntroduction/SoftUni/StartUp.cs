using System.Text;
using SoftUni.Data;
using SoftUni.Models;

public class StartUp
{
    public static void Main()
    {
        SoftUniContext context = new SoftUniContext();
        Console.WriteLine(GetEmployeesInPeriod(context));
    }

    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        return String.Join(Environment.NewLine, context.Employees
            .Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}")
            .ToList());
    }

    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        return String.Join(Environment.NewLine, context.Employees
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .Select(e => $"{e.FirstName} - {e.Salary:f2}"));
    }

    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var employees = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Department,
                e.Salary
            })
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName);

        StringBuilder sb = new StringBuilder();
        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
        }

        return sb.ToString().Trim();
    }

    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        var nakov = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");

        if (nakov != null)
        {
            nakov.Address = address;
            context.SaveChanges();
        }

        var employees = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address.AddressText);

        return String.Join(Environment.NewLine, employees);
    }

    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employeesProjects = context.EmployeesProjects
            .Where(ep => ep.Project.StartDate.Year > 2001 && ep.Project.StartDate.Year <= 2003)
            .Take(10);

        StringBuilder sb = new StringBuilder();
        foreach (var ep in employeesProjects)
        {
            sb.AppendLine(
                $"{ep.Employee.FirstName} {ep.Employee.LastName} - Manager: {ep.Employee.Manager.FirstName} {ep.Employee.Manager.LastName}");

            foreach (var p in ep)
            {
                sb.AppendLine()
            }
        }
    }
}