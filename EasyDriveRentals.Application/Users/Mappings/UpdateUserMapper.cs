using EasyDriveRentals.Application.Users.DTOs;
using EasyDriveRentals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Users.Mappings
{
    public static class UpdateUserMapper
    {
        public static void ToUpdateUserInfo(UserInfo userInfo, UpdateUser updateUser)
        {
            userInfo.IdNumber = updateUser.IdNumber;
            userInfo.FullName = updateUser.FullName;
            userInfo.GenderId = updateUser.GenderId ?? userInfo.GenderId;
            userInfo.PhoneNumber = updateUser.PhoneNumber;
            userInfo.Email = updateUser.Email;
            userInfo.RolId = updateUser.RolId ?? userInfo.RolId;
        }
    }
}
