using EasyDriveRentals.Application.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Roles.Interfaces
{
    public interface IRolService
    {
        Task<List<GetRol>> GetAllRolesAsync();
    }

}
