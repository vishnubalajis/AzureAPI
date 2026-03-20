using AzureAPI.Application.Services;
using AzureAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Employee>> Get()
        {
            var employees = await employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{empId}")]
        
        public async Task<ActionResult<Employee>> GetEmployeeById(int empId)
        {
            var employee = await employeeService.GetEmployeeById(empId);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee(Employee employee)
        {
            await employeeService.AddEmployeeAsync(employee);
            return NoContent();
        }
    }
}
