using EasyDriveRentals.Application.Roles.DTOs;
using EasyDriveRentals.Application.Roles.Exceptions;
using EasyDriveRentals.Application.Roles.Interfaces;
using EasyDriveRentals.Application.Roles.Mappings;
using EasyDriveRentals.Domain.Entities;
using EasyDriveRentals.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Roles.Services
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> _rolRepository;

        public RolService(IGenericRepository<Rol> rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<List<GetRol>> GetAllRolesAsync()
        {
            try
            {
                var roles = await _rolRepository.VerifyDataExistenceAsync();
                var mappedRoles = roles.Select(r => RolMapper.ToGetRol(r)).ToList();

                return mappedRoles;
            }
            catch
            {
                throw new GetRolFailedException();
            }
        }
    }
}
