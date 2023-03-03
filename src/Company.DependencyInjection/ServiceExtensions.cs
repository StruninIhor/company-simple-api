using Company.Database;
using Company.Interface;
using Company.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCompanyServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<CompanyDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("CompanyDb"));
            })
                .AddScoped<IDepartmentsService, DepartmentsService>()
                .AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
