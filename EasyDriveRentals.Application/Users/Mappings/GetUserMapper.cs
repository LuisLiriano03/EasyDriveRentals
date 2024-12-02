using EasyDriveRentals.Application.Roles.DTOs;
using EasyDriveRentals.Application.Users.DTOs;
using EasyDriveRentals.Domain.Entities;
using System;

namespace EasyDriveRentals.Application.Users.Mappings
{
    public static class GetUserMapper
    {
        public static GetUser ToGetUser(UserInfo userInfo)
        {
            return new GetUser
            {
                Id = userInfo.UserId,
                IdNumber = userInfo.IdNumber,
                FullName = userInfo.FullName,
                GenderId = userInfo.GenderId,
                GenderDescription = userInfo.Gender?.GenderName,
                PhoneNumber = userInfo.PhoneNumber,
                Email = userInfo.Email,
                RolId = userInfo.RolId,
                RolDescription = userInfo.Rol?.NameRol,
                IsActive = userInfo.IsActive == true ? 1 : 0
            };
        }

        public static UserInfo ToUserInfo(GetUser getUser)
        {
            return new UserInfo
            {
                UserId = getUser.Id,
                IdNumber = getUser.IdNumber,
                FullName = getUser.FullName,
                GenderId = getUser.GenderId,
                PhoneNumber = getUser.PhoneNumber,
                Email = getUser.Email,
                RolId = getUser.RolId,
                IsActive = getUser.IsActive == 1 ? true : false
            };
        }
    }
}
