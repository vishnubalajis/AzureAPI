
using AzureAPI.Application.Services;
using AzureAPI.CustomMiddleware;
using AzureAPI.Filters;
using AzureAPI.Infrastructure.Data;
using AzureAPI.Infrastructure.Repositories;
using AzureAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace AzureAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // add custom exception filter in global level
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });

            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<EmployeeService>();
            builder.Services.AddScoped<CustomExceptionFilter>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseMiddleware<RequestGlobalException>();

            app.MapControllers();

            app.Run();
        }
    }
}
