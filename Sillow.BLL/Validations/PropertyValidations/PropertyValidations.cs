using Sillow.BLL.Core;
using Sillow.BLL.Dtos.PropertyDtos;
using Sillow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Validations.PropertyValidations
{
    public class PropertyValidations
    {
        private static ServiceResult ValidPropertyCommon(PropertyAddDto propertyAddDto)
        {
            ServiceResult result = new ServiceResult();

            BaseValidation.AddValidation(propertyAddDto.PropertyType, "The property type is required");
            BaseValidation.AddValidation(propertyAddDto.SaleType, "The sale type type is required");
            BaseValidation.AddValidation(propertyAddDto.Price, "The price is required");
            BaseValidation.AddValidation(propertyAddDto.Size, "The size is required");
            BaseValidation.AddValidation(propertyAddDto.RoomAmount, "The amount of rooms is required");
            BaseValidation.AddValidation(propertyAddDto.BathroomAmount, "The amount of bathrooms is required");
            BaseValidation.AddValidation(propertyAddDto.Description, "The description is required");

            result = BaseValidation.ProcessValidations(result);

            return result;
        }

        public static async Task<ServiceResult> PropertyValidToAdd(PropertyAddDto propertyAddDto, IPropertyRepository propertyRepository)
        {
            ServiceResult result = ValidPropertyCommon(propertyAddDto);
            if (result.Success)
            {
                if (propertyAddDto.PropertyType != "Apartment" && propertyAddDto.PropertyType != "House")
                {
                    result.Success = false;
                    result.Message = "You can only choose between Apartment and House for the property type";
                    return result;
                }

                if (propertyAddDto.SaleType != "Rent" && propertyAddDto.SaleType != "Buy")
                {
                    result.Success = false;
                    result.Message = "You can only choose between Rent and Buy for teh sale type";
                    return result;
                }
            }
            return result;
        }
    }
}
