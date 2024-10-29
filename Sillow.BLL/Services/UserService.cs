using Microsoft.Extensions.Logging;
using Sillow.BLL.Contracts;
using Sillow.BLL.Core;
using Sillow.BLL.Dtos.UserDtos;
using Sillow.BLL.Reponses.UserResponses;
using Sillow.BLL.Validations.UserValidations;
using Sillow.DAL.Entities;
using Sillow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService (IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<UserAddResponse> AddUserAsync(UserAddDto userAddDto)
        {
            UserAddResponse result = new();
            try
            {
                var IsValidtoAdd = await UserValidations.IsValidToAdd(userAddDto, _userRepository);
                if (IsValidtoAdd.Success)
                {
                    Models.UserModel userModel = new()
                    {
                        FirstName = userAddDto.FirstName,
                        LastName = userAddDto.LastName,
                        Email = userAddDto.Email,
                        Sex = userAddDto.Sex,
                        PhoneNumber = userAddDto.PhoneNumber,
                        UserName = userAddDto.UserName,
                        Password = userAddDto.Password,
                        Role = userAddDto.Role,
                    };

                    User user = new()
                    {
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        Email = userModel.Email,
                        Sex = userModel.Sex,
                        PhoneNumber = userModel.PhoneNumber,
                        UserName = userModel.UserName,
                        Password = userModel.Password,
                        Role = userModel.Role,
                    };

                    result.Data = await _userRepository.Add(user);
                    result.Message = "User added successfully";
                    return result;

                }
                result.Success = false;
                result.Message = IsValidtoAdd.Message;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.Success = false;
                result.Message = "There was an error adding the user";
                return result;
            }
        }

        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var user = await _userRepository.GetAll();

                result.Data = user.Select(u => new Models.UserModel()
                {
                    FirstName = u.FirstName,
                    LastName= u.LastName,
                    Email = u.Email,
                    Sex = u.Sex,
                    PhoneNumber = u.PhoneNumber,
                    UserName = u.UserName,
                    Role = u.Role,
                }).ToList();

                result.Success = true;
                result.Message = "Users retrieved successfully";
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.Success = false;
                result.Message = "There was an error getting the users";
                return result;
            }
        }

        public async Task<ServiceResult> GetById(int id)
        {
            ServiceResult result = new();

            try
            {
                var user = await _userRepository.GetById(id);

                Models.UserModel userM = new Models.UserModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Sex = user.Sex,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    Role = user.Role,
                };

                result.Data = userM;
                result.Message = "User Found successfully";
                return result;
                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                result.Success = false;
                result.Message = "There was an error getting by ID";
                return result;
            }
        }

        public async Task<UserUpdateResponse> UpdateUser(UserUpdateDto userUpdateDto)
        {
            UserUpdateResponse result = new UserUpdateResponse();

            try
            {
                var isValidToUpdate = await UserValidations.IsValidToUpdate(userUpdateDto, _userRepository);

                if (isValidToUpdate.Success)
                {
                    var userToUpdate = await _userRepository.GetById(userUpdateDto.ID);

                    if (userToUpdate == null)
                    {
                        result.Success = false;
                        result.Message = "User not found";
                        return result;
                    }

                    userToUpdate.FirstName = userUpdateDto.FirstName;
                    userToUpdate.LastName = userUpdateDto.LastName;
                    userToUpdate.PhoneNumber = userUpdateDto.PhoneNumber;

                    result.Data = await _userRepository.Update(userToUpdate);
                    result.Success = true;
                    result.Message = "The user was updated successfully";
                    return result;
                }

                result.Success = false;
                result.Message = isValidToUpdate.Message;
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.Success = false;
                result.Message = "There was an error updating the user";
                return result;
            }
        }
    }
}
