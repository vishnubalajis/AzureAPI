using AzureAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController()
        {
            
        }

        [HttpGet]        
        public ActionResult Get()
        {
            var employees = new List<Employee>
{
    new Employee { Id = 1, Name = "Arun", DepartmentId = 1, Salary = 80000, Age = 30, HireDate = new DateTime(2020, 5, 10), ManagerId = null },
    new Employee { Id = 2, Name = "Priya", DepartmentId = 1, Salary = 95000, Age = 35, HireDate = new DateTime(2018, 3, 12), ManagerId = 1 },
    new Employee { Id = 3, Name = "Karthik", DepartmentId = 1, Salary = 60000, Age = 26, HireDate = new DateTime(2022, 7, 1), ManagerId = 1 },

    new Employee { Id = 4, Name = "Sneha", DepartmentId = 2, Salary = 50000, Age = 28, HireDate = new DateTime(2021, 1, 15), ManagerId = null },
    new Employee { Id = 5, Name = "Rahul", DepartmentId = 2, Salary = 55000, Age = 32, HireDate = new DateTime(2019, 11, 20), ManagerId = 4 },

    new Employee { Id = 6, Name = "Vikram", DepartmentId = 3, Salary = 120000, Age = 40, HireDate = new DateTime(2016, 9, 5), ManagerId = null },
    new Employee { Id = 7, Name = "Divya", DepartmentId = 3, Salary = 75000, Age = 29, HireDate = new DateTime(2020, 6, 18), ManagerId = 6 },
    new Employee { Id = 8, Name = "Sanjay", DepartmentId = 3, Salary = 70000, Age = 27, HireDate = new DateTime(2023, 2, 10), ManagerId = 6 },

    new Employee { Id = 9, Name = "Meena", DepartmentId = 4, Salary = 65000, Age = 31, HireDate = new DateTime(2021, 8, 25), ManagerId = null },
    new Employee { Id = 10, Name = "Ajay", DepartmentId = 4, Salary = 72000, Age = 33, HireDate = new DateTime(2019, 4, 30), ManagerId = 9 },

    // Edge cases for testing
    new Employee { Id = 11, Name = "Ravi", DepartmentId = 1, Salary = 95000, Age = 38, HireDate = new DateTime(2017, 12, 1), ManagerId = 1 }, // same salary as Priya
    new Employee { Id = 12, Name = "Latha", DepartmentId = 2, Salary = 48000, Age = 24, HireDate = new DateTime(2024, 1, 5), ManagerId = 4 }
};
            return Ok(employees);
        }
    }
}
