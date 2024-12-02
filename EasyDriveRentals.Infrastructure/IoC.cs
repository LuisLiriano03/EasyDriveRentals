using EasyDriveRentals.Domain.Interfaces;
using EasyDriveRentals.Infrastructure.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace EasyDriveRentals.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            return service
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }

    }

}
