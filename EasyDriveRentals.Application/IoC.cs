using EasyDriveRentals.Application.Genders.Interfaces;
using EasyDriveRentals.Application.Genders.Services;
using EasyDriveRentals.Application.Roles.Interfaces;
using EasyDriveRentals.Application.Roles.Services;
using EasyDriveRentals.Application.Users.Interfaces;
using EasyDriveRentals.Application.Users.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            return service
                .AddScoped<IRolService, RolService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IGenderService, GenderService>();



        }

    }
}
