namespace AzureAPI.Models
{
    public class UserClaimsDto
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? EmployeeRole { get; set; }

        public List<string> Permissions { get; set;  }

    }
}
