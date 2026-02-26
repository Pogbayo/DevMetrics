public class User
{
    public string? Id { get; set; }
    public string? Name { get; set; } 
    public string? Email { get; set; }
    public int Age { get; set; }
    public string? Country { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? ProductCategory { get; set; }  
    public decimal Amount { get; set; }
    public DateTime OrderDate { get; set; }
    public string? City { get; set; }
    public string? PaymentMethod { get; set; } 
}
public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Department { get; set; }
    public decimal Salary { get; set; }
    public int YearsWithCompany { get; set; }
    public string? City { get; set; }
}

class Program
{
    static void Main()
    {

        var users = new List<User>
        {
            new User { Id = "u1", Name = "Alice",   Email = "alice@gmail.com",   Age = 25, Country = "USA" },
            new User { Id = "u2", Name = "Bob",     Email = "bob@yahoo.com",     Age = 30, Country = "UK"  },
            new User { Id = "u3", Name = "Charlie", Email = "charlie@gmail.com", Age = 22, Country = "USA" },
            new User { Id = "u4", Name = "Diana",   Email = "diana@hotmail.com", Age = 28, Country = "Canada" },
            new User { Id = "u5", Name = "Eve",     Email = "eve@gmail.com",     Age = 35, Country = "UK"  },
            new User { Id = "u6", Name = "Frank",   Email = "frank@yahoo.com",   Age = 40, Country = "USA" },
            new User { Id = "u7", Name = "Grace",   Email = "grace@gmail.com",   Age = 27, Country = "Canada" },
            new User { Id = "u8", Name = "Henry",   Email = "henry@yahoo.com",   Age = 33, Country = "USA" },
        };

        var orders = new List<Order>
        {
            new() { Id = 1, CustomerName = "Alice",   ProductCategory = "Electronics", Amount = 1200, OrderDate = new(2025, 01, 15), City = "London",    PaymentMethod = "Card" },
            new() { Id = 2, CustomerName = "Bob",     ProductCategory = "Clothing",     Amount = 85,  OrderDate = new(2025, 02, 03), City = "Manchester", PaymentMethod = "Cash" },
            new() { Id = 3, CustomerName = "Charlie", ProductCategory = "Electronics", Amount = 450,  OrderDate = new(2025, 01, 20), City = "London",    PaymentMethod = "PayPal" },
            new() { Id = 4, CustomerName = "Diana",   ProductCategory = "Books",       Amount = 45,  OrderDate = new(2025, 03, 10), City = "Birmingham", PaymentMethod = "Card" },
            new() { Id = 5, CustomerName = "Eve",     ProductCategory = "Electronics", Amount = 2200, OrderDate = new(2025, 02, 14), City = "London",    PaymentMethod = "Card" },
            new() { Id = 6, CustomerName = "Frank",   ProductCategory = "Clothing",     Amount = 150, OrderDate = new(2025, 01, 05), City = "Manchester", PaymentMethod = "PayPal" },
            new() { Id = 7, CustomerName = "Grace",   ProductCategory = "Books",       Amount = 120, OrderDate = new(2025, 03, 01), City = "Birmingham", PaymentMethod = "Cash" },
            new() { Id = 8, CustomerName = "Henry",   ProductCategory = "Electronics", Amount = 800,  OrderDate = new(2025, 02, 28), City = "London",    PaymentMethod = "Card" },
            new() { Id = 9, CustomerName = "Ivy",     ProductCategory = "Clothing",     Amount = 300, OrderDate = new(2025, 01, 30), City = "Manchester", PaymentMethod = "Card" },
            new() { Id = 10, CustomerName = "Jack",   ProductCategory = "Books",       Amount = 200, OrderDate = new(2025, 03, 15), City = "London",    PaymentMethod = "PayPal" },
            new() { Id = 11, CustomerName = "Alice",  ProductCategory = "Electronics", Amount = 600,  OrderDate = new(2025, 02, 10), City = "London",    PaymentMethod = "Card" },
            new() { Id = 12, CustomerName = "Bob",    ProductCategory = "Books",       Amount = 80,  OrderDate = new(2025, 03, 20), City = "Manchester", PaymentMethod = "Cash" }
        };



        var employees = new List<Employee>
        {
            new() { Id = 1, Name = "Alice",   Department = "Engineering", Salary = 95000, YearsWithCompany = 4, City = "London" },
            new() { Id = 2, Name = "Bob",     Department = "Marketing",   Salary = 62000, YearsWithCompany = 2, City = "Manchester" },
            new() { Id = 3, Name = "Charlie", Department = "Engineering", Salary = 110000, YearsWithCompany = 8, City = "London" },
            new() { Id = 4, Name = "Diana",   Department = "HR",          Salary = 58000, YearsWithCompany = 1, City = "Birmingham" },
            new() { Id = 5, Name = "Eve",     Department = "Engineering", Salary = 88000, YearsWithCompany = 3, City = "London" },
            new() { Id = 6, Name = "Frank",   Department = "Sales",       Salary = 72000, YearsWithCompany = 5, City = "Manchester" },
            new() { Id = 7, Name = "Grace",   Department = "HR",          Salary = 65000, YearsWithCompany = 6, City = "Birmingham" },
            new() { Id = 8, Name = "Henry",   Department = "Sales",       Salary = 68000, YearsWithCompany = 2, City = "London" },
            new() { Id = 9, Name = "Ivy",     Department = "Engineering", Salary = 105000, YearsWithCompany = 7, City = "Manchester" },
            new() { Id = 10, Name = "Jack",   Department = "Marketing",   Salary = 59000, YearsWithCompany = 1, City = "London" }
        };



        //Users
        var group1 = users.GroupBy(u => u.Email!.Split('@')[1])
            .Select(g => new
            {
                Domain = g.Key,
                NumberOfUsers = g.Count()
            });

        var group2 = users.GroupBy(u => u.Country)
            .Select(g => new 
            {
              Country = g.Key,
              AvgAge = g.Average(u => u.Age),
              UserCount = g.Count()
            });

        var group3 = users.GroupBy(u => u.Age < 30 ? "Young" : u.Age < 40 ? "Adult" : "Senior")
            .Select(g => new
            {
                AgeGroup = g.Key,
                Names = string.Join(",", g.Select(u => u.Name)),
                Count = g.Count()
            });

        var group4 = users.GroupBy(u => u.Name![0])
            .Select(g => new
            {
                FirstLetter = g.Key,
                Count = g.Count(),
                OldestPerson = g
                .OrderByDescending(u => u.Age)
                .First()
                .Name
            })
            .ToList();



        //Employees
        var groupByDept = employees.GroupBy(e => e.Department)
            .Select(g => new
            {
                DepartmentName = g.Key,
                Count = g.Count(),
                TotalSalary = g.Sum(g => g.Salary),
                AverageSalary = Math.Round(g.Average(e => e.YearsWithCompany), 1)
            })
            .OrderByDescending(g => g.TotalSalary)
            .ToList();


        var groupByCity = employees.GroupBy(e => e.City)
            .Select(g => new
            {
                City = g.Key,
                Count = g.Count(),
                HighestSalary = g.Select(e => e.Salary).Max(),
                AllNames = string.Join(",", g.Select(e => e.Name))
            });

        var groupBySalaryRange = employees.GroupBy(u =>
              u.Salary < 70000 ? "Low"
              : u.Salary < 10000 ? "Mid" :
              "High")
            .Select(g => new
            {
                rangeName = g.Key,
                NumberOfEmployess = g.Count(),
                AverageSalary = g.Average(e => e.Salary),
                NamesOfEmployees = string.Join(".", g.Select(e => e.Name))
            });

        var groupByNameFirstLetterAndDept = employees
            .GroupBy(e => new { FirstLetter = e.Name![0], Department = e.Department })
            .Where(g=> g.Count()>1)
            .Select(g => new
            {
                FirstLetter = g.Key.FirstLetter,
                Department = g.Key.Department,
                Count = g.Count(),
                TotalSalary = g.Sum(e => e.Salary)
            });


        //Orders

        var groupByProductCategory = orders.GroupBy(o => o.ProductCategory)
            .Where(g => g.Count() > 3)
            .Select(g => new
            {
                Category = g.Key,
                OrderCount = g.Count(),
                TotalAmount = g.Sum(o => o.Amount),
                AverageAmount = Math.Round(g.Average(e => e.Amount), 2),
            });

        var groupByCityPlusPaymentMethod = orders.GroupBy(o => new { City = o.City, PaymentMethod = o.PaymentMethod })
            .Where(g => g.Sum(o => o.Amount) > 500)
            .Select(g => new
            {
                City = g.Key,
                PaymentMethod = g.Select(o => o.PaymentMethod),
                OrderCount = g.Count(),
                TotalAmount = g.Sum(o => o.Amount),
                HighestSingleOrderAmount = g.Max(o => o.Amount)
            });

        var groupByMonthOfOrderdate = orders
            .GroupBy(o => o.OrderDate.ToString("yyyy-MM"))
            .Select(outerGroup => new
            {
                Month = outerGroup.Key,
                OrderCount = outerGroup.Count(),
                TotalRevenue = outerGroup.Sum(o => o.Amount),

                MostPopularCategory = outerGroup
                .GroupBy(innerOrder => innerOrder.ProductCategory)
                .OrderByDescending(catGroup => catGroup.Count())
                .Select(catGroup => catGroup.Key)
                .FirstOrDefault() ?? "None",
                 
                ListOfCustomersThatOrderedThatMonth = string.Join(", ", outerGroup.Select(o => o.CustomerName).Distinct())
            })
            .OrderByDescending(g => g.Month)
            .ToList();
    }
}