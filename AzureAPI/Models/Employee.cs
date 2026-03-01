namespace AzureAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        public decimal Salary { get; set; }

        public int Age { get; set; }

        public DateTime HireDate { get; set; }

        public int? ManagerId { get; set; }
    }
}
