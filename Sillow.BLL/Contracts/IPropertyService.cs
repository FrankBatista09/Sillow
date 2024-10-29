using Sillow.BLL.Core;
using Sillow.BLL.Dtos.PropertyDtos;
using Sillow.BLL.Reponses.PropertyResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Contracts
{
    public interface IPropertyService : IBaseService
    {
        Task<PropertyAddResponse> AddPropertyAsync(PropertyAddDto propertyAddDto);
        Task<PropertyUpdateResponse> UpdateProperty(PropertyUpdateDto propertyUpdateDto);
        Task<PropertyDeleteResponse> DeleteProperty(PropertyDeleteDto propertyDeleteDtio);

    }
}
