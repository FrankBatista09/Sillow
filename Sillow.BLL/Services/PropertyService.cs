using Microsoft.Extensions.Logging;
using Sillow.BLL.Contracts;
using Sillow.BLL.Core;
using Sillow.BLL.Dtos.PropertyDtos;
using Sillow.BLL.Reponses.PropertyResponses;
using Sillow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ILogger<PropertyService> _logger;

        public PropertyService(IPropertyRepository propertyRepository, ILogger<PropertyService> logger)
        {
            _propertyRepository = propertyRepository;
            _logger = logger;
        }
        public Task<PropertyAddResponse> AddPropertyAsync(PropertyAddDto propertyAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyDeleteResponse> DeleteProperty(PropertyDeleteDto propertyDeleteDtio)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyUpdateResponse> UpdateProperty(PropertyUpdateDto propertyUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
