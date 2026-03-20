using AzureAPI.Models;
using AzureAPI.Repository;

namespace AzureAPI.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly ILoggerService _logger;
        private readonly ILogger<EmployeeService> _logger1;

        public EmployeeService(IEmployeeRepository repository, ILoggerService logger, ILogger<EmployeeService> logger1)
        {
            _repository = repository;
            _logger = logger;
            _logger1 = logger1;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            _logger.Log("Get Employee");
            _logger1.LogInformation("Get all Employee");
            return await _repository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _repository.GetByIdAsync(id)??new Employee();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _repository.AddAsync(employee);
        }
    }
}
