using EasyDriveRentals.Application.Genders.DTOs;
using EasyDriveRentals.Application.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Genders.Interfaces
{
    public interface IGenderService
    {
        Task<List<GetGender>> GetAllGenderAsync();
    }
}
