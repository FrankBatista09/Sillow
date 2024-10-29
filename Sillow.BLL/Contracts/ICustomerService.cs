using Sillow.BLL.Core;
using Sillow.BLL.Dtos.CustomerDtos;
using Sillow.BLL.Reponses.CustomerResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Contracts
{
    public interface ICustomerService : IBaseService
    {
        Task<CustomerUpdateResponse> UpdateCustomer(CustomerUpdateDto customerUpdateDto);
    }
}
