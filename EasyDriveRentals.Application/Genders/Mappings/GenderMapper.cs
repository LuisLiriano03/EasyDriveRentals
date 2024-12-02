using EasyDriveRentals.Application.Genders.DTOs;
using EasyDriveRentals.Application.Roles.DTOs;
using EasyDriveRentals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Genders.Mappings
{
    public static class GenderMapper
    {
        public static GetGender ToGetGender(GenderInfo genderInfo)
        {
            return new GetGender
            {
                Id = genderInfo.GenderId,
                Name = genderInfo.GenderName
            };
        }

        public static GenderInfo ToGenderInfo(GetGender getGender)
        {
            return new GenderInfo
            {
                GenderId = getGender.Id,
                GenderName = getGender.Name
            };
        }
    }
}
