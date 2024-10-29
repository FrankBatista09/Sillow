using Sillow.BLL.Core;
using Sillow.BLL.Dtos.AdminDtos;
using Sillow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Validations.AdminValidations
{
    public class AdminValidations
    {
        private static ServiceResult ValidAdminCommon(AdminUpdateDto adminUpdateDto)
        {
            ServiceResult result = new ServiceResult();

            BaseValidation.AddValidation(adminUpdateDto.FirstName, "The first name is required for the admin");
            BaseValidation.AddValidation(adminUpdateDto.LastName, "The last name is required for the admin");
            BaseValidation.AddValidation(adminUpdateDto.PhoneNumber, "The phone number is required for the admin");

            result = BaseValidation.ProcessValidations(result);

            return result;

        }

        public static async Task<ServiceResult> IsValidAdminToUpdate(AdminUpdateDto adminUpdateDto, IAdminRepository  adminRepository)
        {
            ServiceResult result = new ServiceResult();
            result = ValidAdminCommon(adminUpdateDto);

            if (result.Success)
            {
                if(!await adminRepository.Exist(a => a.ID == adminUpdateDto.ID))
                {
                    result.Success = false;
                    result.Message = "This admin does not exist";
                    return result;  
                }

                if(await adminRepository.Exist(a => a.PhoneNumber == adminUpdateDto.PhoneNumber && a.ID != adminUpdateDto.ID))
                {
                    result.Success = false;
                    result.Message = "This Phone number is already taken";
                    return result;
                }

                if (!BaseValidation.IsPhoneNumberValid(adminUpdateDto.PhoneNumber))
                {
                    result.Success = false;
                    result.Message = "The phone number format is not valid";
                    return result;
                }
            }
            return result;
        }
    }
}
