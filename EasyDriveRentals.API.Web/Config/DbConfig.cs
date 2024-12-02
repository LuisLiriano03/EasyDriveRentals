using EasyDriveRentals.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyDriveRentals.API.Web.Config
{
    public static class DbConfig
    {
        public static IServiceCollection ConfigDbConnection(this IServiceCollection service, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            service.AddDbContext<AutoRentalDBContext>(options => options.UseSqlServer(connectionString));

            return service;
        }
    }
}
