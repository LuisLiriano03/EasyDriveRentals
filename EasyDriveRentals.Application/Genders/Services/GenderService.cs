using EasyDriveRentals.Application.Genders.DTOs;
using EasyDriveRentals.Application.Genders.Exceptions;
using EasyDriveRentals.Application.Genders.Interfaces;
using EasyDriveRentals.Application.Genders.Mappings;
using EasyDriveRentals.Application.Roles.DTOs;
using EasyDriveRentals.Application.Roles.Exceptions;
using EasyDriveRentals.Application.Roles.Mappings;
using EasyDriveRentals.Domain.Entities;
using EasyDriveRentals.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Genders.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenericRepository<GenderInfo> _genericRepository;

        public GenderService(IGenericRepository<GenderInfo> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<List<GetGender>> GetAllGenderAsync()
        {
            try
            {
                var genders = await _genericRepository.VerifyDataExistenceAsync();
                var mappedGenders = genders.Select(r => GenderMapper.ToGetGender(r)).ToList();

                return mappedGenders;
            }
            catch
            {
                throw new GetGenderFailedException();
            }
        }
    }
}
