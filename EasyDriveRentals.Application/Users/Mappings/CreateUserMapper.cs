using EasyDriveRentals.Application.Users.DTOs;
using EasyDriveRentals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Users.Mappings
{
    public static class CreateUserMapper
    {
        public static UserInfo ToUserInfo(CreateUser createUser)
        {
            return new UserInfo
            {
                IdNumber = createUser.IdNumber,
                FullName = createUser.FullName,
                GenderId = createUser.GenderId,
                PhoneNumber = createUser.PhoneNumber,
                Email = createUser.Email,
                PasswordHash = createUser.PasswordHash,
                RolId = createUser.RolId
            };
        }
    }
}
