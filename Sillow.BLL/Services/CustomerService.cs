using Microsoft.Extensions.Logging;
using Sillow.BLL.Contracts;
using Sillow.BLL.Core;
using Sillow.BLL.Dtos.CustomerDtos;
using Sillow.BLL.Reponses.CustomerResponses;
using Sillow.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(CustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public Task<ServiceResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerUpdateResponse> UpdateCustomer(CustomerUpdateDto customerUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
