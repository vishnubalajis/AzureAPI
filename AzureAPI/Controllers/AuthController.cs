using AzureAPI.Application.Services;
using AzureAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public AuthController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if(username =="admin" && password == "123")
            {
                var claims = new UserClaimsDto() {
                    EmployeeId = 1,
                    EmployeeName = username,
                    EmployeeEmail = "vishnu@gmail.com",
                    EmployeeRole="Admin"};
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
