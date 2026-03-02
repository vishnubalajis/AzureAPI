using AzureAPI.Application.Services;
using AzureAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]        
        public async Task<ActionResult<Employee>> Get()
        {
            var employees = await employeeService.GetEmployeesAsync();
            throw new Exception("Failed");
            return Ok(employees);
        }
    }
}
