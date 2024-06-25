using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

public class StartUp
{
    public static void Main()
    {
        SoftUniContext context = new SoftUniContext();
        Console.WriteLine(IncreaseSalaries(context));
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
        var result = context.Employees
            .Take(10)
            .Select(e => new
            {
                EmployeeNames = $"{e.FirstName} {e.LastName}",
                ManagerNames = $"{e.Manager.FirstName} {e.Manager.LastName}",
                Projects = e.EmployeesProjects
                    .Where(ep 
                        => ep.Project.StartDate.Year >= 2001
                        && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ep.Project.StartDate,
                        ep.Project.EndDate
                    })
            });

        StringBuilder sb = new StringBuilder();
        foreach (var ep in result)
        {
            sb.AppendLine($"{ep.EmployeeNames} - Manager: {ep.ManagerNames}");

            if (ep.Projects.Any())
            {
                foreach (var project in ep.Projects)
                {
                    string endDate = "";
                    if (project.EndDate is null)
                    {
                        endDate = "not finished";
                    }
                    else 
                    {
                        endDate = project.EndDate.ToString();
                    }
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate:M/d/yyyy h:mm:ss tt} - {endDate:M/d/yyyy h:mm:ss tt}");
                }
            }
        }

        return sb.ToString().Trim();
    }

    public static string GetAddressesByTown(SoftUniContext context)
    {
        var addresses = context.Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => new
            {
                AddressTextProp = a.AddressText,
                TownName = a.Town.Name,
                EmployeeCount = a.Employees.Count
            });

        StringBuilder sb = new StringBuilder();
        foreach (var address in addresses)
        {
            sb.AppendLine($"{address.AddressTextProp}, {address.TownName} - {address.EmployeeCount} employees");
        }

        return sb.ToString().Trim();
    }

    public static string GetEmployee147(SoftUniContext context)
    {
        int employeeId = 147;
        
        var employee147 = context.Employees
            .FirstOrDefault(e => e.EmployeeId == employeeId);

        var projects = context.Employees
            .Where(e => e.EmployeeId == employeeId)
            .SelectMany(e => e.EmployeesProjects)
            .OrderBy(ep => ep.Project.Name)
            .Select(ep => new
            {
                ep.Project
            })
            .ToList();
        
        StringBuilder sb = new StringBuilder();
        if (employee147 is not null)
        {
            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (var employeeProject in projects)
            {
                sb.AppendLine(employeeProject.Project.Name);
            }
        }

        return sb.ToString().Trim();
    }

    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                DepartmentName = d.Name,
                ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                EmployeeList = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        EmployeeName = $"{e.FirstName} {e.LastName}",
                        e.JobTitle
                    })
            });

        StringBuilder sb = new StringBuilder();
        foreach (var department in departments)
        {
            sb.AppendLine($"{department.DepartmentName} - {department.ManagerName}");

            foreach (var employee in department.EmployeeList)
            {
                sb.AppendLine($"{employee.EmployeeName} - {employee.JobTitle}");
            }
        }

        return sb.ToString().Trim();
    }

    public static string GetLatestProjects(SoftUniContext context)
    {
        var projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .Select(p => new
            {
                ProjectName = p.Name,
                ProjectDescription = p.Description,
                p.StartDate
            })
            .OrderBy(p => p.ProjectName);

        StringBuilder sb = new StringBuilder();
        foreach (var project in projects)
        {
            sb.AppendLine(project.ProjectName);
            sb.AppendLine(project.ProjectDescription);
            sb.AppendLine($"{project.StartDate:M/d/yyyy h:mm:ss tt}");
        }

        return sb.ToString().Trim();
    }

    public static string IncreaseSalaries(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.Department.Name == "Engineering"
                        || e.Department.Name == "Tool Design"
                        || e.Department.Name == "Marketing"
                        || e.Department.Name == "Information Services")
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName);

        StringBuilder sb = new StringBuilder();
        foreach (Employee employee in employees)
        {
            decimal newSalary = (decimal)1.12 * employee.Salary;
            employee.Salary = newSalary;

            sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
        }

        return sb.ToString().Trim();
    }
}