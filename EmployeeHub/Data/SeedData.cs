using EmployeeHub.Data;
using EmployeeHub.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider, AppDbContext context)
    {
        if (!context.Departments.Any())
        {
            context.Departments.AddRange(
                new Department { DepartmentName = "Engineering" },
                new Department { DepartmentName = "Sales" },
                new Department { DepartmentName = "HR" }
            );
            context.SaveChanges();
        }

        if (!context.Employees.Any())
        {
            context.Employees.AddRange(
                new Employee { FirstName = "Alice", LastName = "Smith", DepartmentID = 1, HireDate = DateTime.Parse("2022-01-15") },
                new Employee { FirstName = "Bob", LastName = "Johnson", DepartmentID = 2, HireDate = DateTime.Parse("2021-07-20") },
                new Employee { FirstName = "Carol", LastName = "White", DepartmentID = 3, HireDate = DateTime.Parse("2020-05-18") }
            );
            context.SaveChanges();
        }

        // Populate SalaryHistory for testing
        var random = new Random();
        var employees = context.Employees.ToList();
        foreach (var employee in employees)
        {
            for (int i = 0; i < 10; i++) // Add 10 random salary records per employee
            {
                context.SalaryHistories.Add(new SalaryHistory
                {
                    EmployeeID = employee.EmployeeID,
                    SalaryAmount = random.Next(30000, 60000),
                    EffectiveDate = DateTime.Now.AddMonths(-random.Next(1, 24)), // Random date in the past 2 years
                    DepartmentID = employee.DepartmentID
                });
            }
        }
        context.SaveChanges();
    }
}
