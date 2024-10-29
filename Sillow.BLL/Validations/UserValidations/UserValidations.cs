using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Sillow.BLL.Core;
using Sillow.BLL.Dtos.UserDtos;
using Sillow.BLL.Models;
using Sillow.DAL.Interfaces;
using Sillow.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Validations.UserValidations
{
    public class UserValidations
    {
        private static ServiceResult ValidUserCommon(UserAddDto userAddDto)
        {
            ServiceResult result = new ServiceResult();



            BaseValidation.AddValidation(userAddDto.FirstName, "The First Name for the user is required");
            BaseValidation.AddValidation(userAddDto.LastName, "The last name for the user is required");
            BaseValidation.AddValidation(userAddDto.Email, "The Email for the user is required");
            BaseValidation.AddValidation(userAddDto.PhoneNumber, "The Phone number for the user is required");
            BaseValidation.AddValidation(userAddDto.Sex, "The Sex for the user is required");
            BaseValidation.AddValidation(userAddDto.UserName, "The username for the user is required");
            BaseValidation.AddValidation(userAddDto.Password, "The password for the user is required");
            BaseValidation.AddValidation(userAddDto.Role, "The role for the user is required");

            result = BaseValidation.ProcessValidations(result);

            return result;

        }
        public static async Task<ServiceResult> IsValidToAdd(UserAddDto userAddDto, IUserRepository userRepository)
        {
            ServiceResult result = ValidUserCommon(userAddDto);

            if (result.Success)
            {
                bool userExist = await userRepository.Exist(us => us.UserName == userAddDto.UserName && us.Email == userAddDto.Email);
                if (userExist)
                {
                    result.Success = false;
                    result.Message = "The username or email is already taken";
                }

                if (await userRepository.Exist(us => us.PhoneNumber == userAddDto.PhoneNumber))
                {
                    result.Success=false;
                    result.Message = "This Phone Number is already taken";
                }

                if (userAddDto.Sex != "Male" && userAddDto.Sex != "Female")
                {
                    result.Success = false;
                    result.Message = "You can only choose between two options, Male or Female";
                    return result;
                }

                if (userAddDto.Role != "Admin" && userAddDto.Role != "Agent" && userAddDto.Role != "Customer")
                {
                    result.Success = false;
                    result.Message = "You can only choose between: Admin, Agent or Customer";
                    return result;
                }
            }

            return result;

        }

        public static async Task<ServiceResult> IsValidToUpdate(UserUpdateDto userUpdateDto, IUserRepository userRepository)
        {
            ServiceResult result = new();

            UserAddDto userAddDto = new()
            {
                FirstName = userUpdateDto.FirstName,
                LastName = userUpdateDto.LastName,
                PhoneNumber = userUpdateDto.PhoneNumber,
            };

            result = ValidUserCommon(userAddDto);
            if (result.Success)
            {
                if (await userRepository.Exist(u => u.PhoneNumber == userUpdateDto.PhoneNumber && u.ID != userUpdateDto.ID))
                {
                    result.Success = false;
                    result.Message = "This phone number is already taken";
                    return result;
                }

                if (!await userRepository.Exist(u => u.ID == userUpdateDto.ID))
                {
                    result.Success = false;
                    result.Message = "This user does not exist";
                    return result;
                }

                if (!BaseValidation.IsPhoneNumberValid(userUpdateDto.PhoneNumber))
                {
                    result.Success = false;
                    result.Message = "The phone number format is not valid";
                }
            }
            return result;
        }
        
    }
}
