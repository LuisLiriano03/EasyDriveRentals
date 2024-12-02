using EasyDriveRentals.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<GetUser> GetUserByIdAsync(int id);
        Task<List<GetUser>> GetAllUserAsync();
        Task<GetUser> Register(CreateUser model);
        Task<bool> UpdateAsync(UpdateUser model);
        Task<bool> SoftDeleteAsync(int id);

    }
}
