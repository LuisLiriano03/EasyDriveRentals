using EasyDriveRentals.Application.Roles.DTOs;
using EasyDriveRentals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Roles.Mappings
{
    public static class RolMapper
    {
        public static GetRol ToGetRol(Rol rol)
        {
            return new GetRol
            {
                Id = rol.RolId,
                Name = rol.NameRol
            };
        }

        public static Rol ToRol(GetRol getRol)
        {
            return new Rol
            {
                RolId = getRol.Id,
                NameRol = getRol.Name
            };
        }
    }

}
