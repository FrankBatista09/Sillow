using Microsoft.EntityFrameworkCore.Diagnostics;
using Sillow.BLL.Core;
using Sillow.BLL.Dtos.CustomerDtos;
using Sillow.BLL.Dtos.UserDtos;
using Sillow.BLL.Models;
using Sillow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Validations.CustomerValidations
{
    public class CustomerValidations
    {
        private static ServiceResult ValidCustomerCommon(CustomerUpdateDto customerUpdateDto)
        {
            ServiceResult result = new ServiceResult();
            BaseValidation.AddValidation(customerUpdateDto.FirstName, "The first name for the customer is required");
            BaseValidation.AddValidation(customerUpdateDto.LastName, "The last name for the customer is required");
            BaseValidation.AddValidation(customerUpdateDto.PhoneNumber, "The phone number for the customer is required");

            result = BaseValidation.ProcessValidations(result);
            return result;  
        }

        public static async Task<ServiceResult> IsCustomerValidToUpdate(CustomerUpdateDto customerUpdateDto, ICustomerRepository customerRepository)
        {
            ServiceResult result = new();
            result = ValidCustomerCommon(customerUpdateDto);

            if (result.Success)
            {
                if (await customerRepository.Exist(c => c.PhoneNumber == customerUpdateDto.PhoneNumber && c.ID != customerUpdateDto.ID))
                {
                    result.Success = false;
                    result.Message = "This Phone Number is already taken";
                    return result; 
                }

                if (!await customerRepository.Exist(c => c.ID == customerUpdateDto.ID)){

                    result.Success = false;
                    result.Message = "This customer does not exist";
                    return result;
                }

                if (!BaseValidation.IsPhoneNumberValid(customerUpdateDto.PhoneNumber))
                {
                    result.Success = false;
                    result.Message = "The phone number forma is invalid";
                    return result;
                }
            }
            return result;
        }
    }
}
