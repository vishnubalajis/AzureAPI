using AzureAPI.Application.Services;
using AzureAPI.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private static readonly ILog log = LogManager.GetLogger(typeof(AuthController));
        public AuthController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            log.Info("Logging Initiated");

            if(username =="admin" && password == "123")
            {
                var claims = new UserClaimsDto() {
                    EmployeeId = 1,
                    EmployeeName = username,
                    EmployeeEmail = "vishnu@gmail.com",
                    EmployeeRole="Admin",
                    Permissions = new List<string> { "Employee.InsertEmployee", "Employee.Delete" }
                };
                var token = tokenService.CreateToken(claims);
                return Ok(new { token });
            }

            if(username =="user" && password == "123")
            {
                var claims = new UserClaimsDto()
                {
                    EmployeeId = 1,
                    EmployeeName = username,
                    EmployeeEmail = "balaji@gmail.com",
                    EmployeeRole = "User"
                };
                var token = tokenService.CreateToken(claims);
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }
}
