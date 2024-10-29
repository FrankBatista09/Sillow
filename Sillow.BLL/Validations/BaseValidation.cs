using Microsoft.VisualBasic;
using Sillow.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Validations
{
    public class BaseValidation
    {
        private static List<(dynamic value, string ErrorMessage)> validations = new List<(dynamic value, string ErrorMessage)>();

        public static void AddValidation(dynamic value, string errorMessage)
        {
            validations.Add((value, errorMessage));
        }

        public static void SetError(ServiceResult result, string message)
        {
            result.Success = false;
            result.Message = message;
        }

        public static ServiceResult ProcessValidations(ServiceResult result)
        {
            foreach (var validation in validations)
            {
                if (validation.value.IsNullOrEmpty())
                {
                    SetError(result, validation.ErrorMessage);
                    return result;
                }
                
            }
            return result;

        }

        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit) && phoneNumber.Length == 10;
        }
    }
}

