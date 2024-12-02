using EasyDriveRentals.Application.Roles.Mappings;
using EasyDriveRentals.Application.Users.DTOs;
using EasyDriveRentals.Application.Users.Exceptions;
using EasyDriveRentals.Application.Users.Interfaces;
using EasyDriveRentals.Application.Users.Mappings;
using EasyDriveRentals.Application.Users.Validators;
using EasyDriveRentals.Domain.Entities;
using EasyDriveRentals.Domain.Enums;
using EasyDriveRentals.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<UserInfo> _userRepository;

        public UserService(IGenericRepository<UserInfo> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<GetUser> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetUser>> GetAllUserAsync()
        {
            try
            {
                var userQuery = await _userRepository.VerifyDataExistenceAsync();
                var listUser = userQuery
                    .Include(user => user.Gender)
                    .Include(user => user.Rol).ToList();

                var mappedUsers = listUser.Select(user => GetUserMapper.ToGetUser(user)).ToList();

                return mappedUsers;
            }
            catch
            {
                throw new GetUsersFailedException();
            }
        }


        //public async Task<GetUser> Register(CreateUser model)
        //{
        //    try
        //    {
        //        var createUserValidator = new CreateUserValidator();
        //        var validationResult = createUserValidator.Validate(model);

        //        if (!validationResult.IsValid)
        //        {
        //            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
        //            throw new TaskCanceledException($"{string.Join(", ", errors)}");
        //        }

        //        var userInfo = CreateUserMapper.ToUserInfo(model);

        //        var existingUser = await _userRepository.VerifyDataExistenceAsync(
        //            u => u.IdNumber == userInfo.IdNumber ||
        //                u.PhoneNumber == userInfo.PhoneNumber ||
        //                u.Email == userInfo.Email
        //            );

        //        if (existingUser.Any())
        //        {
        //            var errorMessage = string.Empty;

        //            errorMessage += existingUser.Any(u => u.IdNumber == userInfo.IdNumber) ? $"{UserValidationFields.IdNumber}, " : "";
        //            errorMessage += existingUser.Any(u => u.PhoneNumber == userInfo.PhoneNumber) ? $"{UserValidationFields.PhoneNumber}, " : "";
        //            errorMessage += existingUser.Any(u => u.Email == userInfo.Email) ? $"{UserValidationFields.Email}, " : "";

        //            errorMessage = errorMessage.TrimEnd(new char[] { ',', ' ' });

        //            throw new UserAlreadyExistsException(errorMessage);
        //        }

        //        var userCreated = await _userRepository.CreateAsync(userInfo);

        //        var userException = userCreated.UserId == (int)DataCreationOption.DoNotCreate ? throw new UserNotCreatedException() : userCreated;

        //        var query = await _userRepository.VerifyDataExistenceAsync(u => u.UserId == userCreated.UserId);
        //        userCreated = query
        //            .Include(rol => rol.Gender)
        //            .Include(rol => rol.Rol).First();

        //        return GetUserMapper.ToGetUser(userCreated);
        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //}


        public async Task<GetUser> Register(CreateUser model)
        {
            try
            {
                ValidateUserModel(model);

                var userInfo = CreateUserMapper.ToUserInfo(model);
                await CheckIfUserExists(userInfo);

                var userCreated = await CreateUserAsync(userInfo);
                await VerifyUserCreation(userCreated);

                var userWithDetails = await GetUserWithDetails(userCreated.UserId);
                return MapToGetUser(userWithDetails);
            }
            catch (UserAlreadyExistsException ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        private void ValidateUserModel(CreateUser model)
        {
            var createUserValidator = new CreateUserValidator();
            var validationResult = createUserValidator.Validate(model);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                throw new TaskCanceledException($"Validation failed: {string.Join(", ", errors)}");
            }
        }

        private async Task CheckIfUserExists(UserInfo userInfo)
        {
            var existingUser = await _userRepository.VerifyDataExistenceAsync(
                u => u.IdNumber == userInfo.IdNumber ||
                     u.PhoneNumber == userInfo.PhoneNumber ||
                     u.Email == userInfo.Email ||
                     u.PasswordHash == userInfo.PasswordHash
            );

            if (existingUser.Any())
            {
                var errorMessage = GenerateErrorMessage(existingUser, userInfo);
                throw new UserAlreadyExistsException(errorMessage);
            }
        }

        private string GenerateErrorMessage(IEnumerable<UserInfo> existingUser, UserInfo userInfo)
        {
            var errorMessage = string.Empty;

            errorMessage += existingUser.Any(u => u.IdNumber == userInfo.IdNumber) ? $"{UserValidationFields.Cedula}, " : "";
            errorMessage += existingUser.Any(u => u.PhoneNumber == userInfo.PhoneNumber) ? $"{UserValidationFields.Telefono}, " : "";
            errorMessage += existingUser.Any(u => u.Email == userInfo.Email) ? $"{UserValidationFields.Correo}, " : "";
            errorMessage += existingUser.Any(u => u.PasswordHash == userInfo.PasswordHash) ? $"{UserValidationFields.Clave}, " : "";

            return errorMessage.TrimEnd(new char[] { ',', ' ' });
        }

        private async Task<UserInfo> CreateUserAsync(UserInfo userInfo)
        {
            return await _userRepository.CreateAsync(userInfo);
        }

        private async Task VerifyUserCreation(UserInfo userCreated)
        {
            var userException = userCreated.UserId == (int)DataCreationOption.DoNotCreate ? throw new UserNotCreatedException() : userCreated;
        }

        private async Task<UserInfo> GetUserWithDetails(int userId)
        {
            var query = await _userRepository.VerifyDataExistenceAsync(u => u.UserId == userId);
            return query.Include(rol => rol.Gender)
                        .Include(rol => rol.Rol)
                        .FirstOrDefault();
        }

        private GetUser MapToGetUser(UserInfo userInfo)
        {
            return GetUserMapper.ToGetUser(userInfo);
        }




        /////////






        public async Task<bool> UpdateAsync(UpdateUser model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
