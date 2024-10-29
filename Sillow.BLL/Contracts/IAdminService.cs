using Sillow.BLL.Core;
using Sillow.BLL.Dtos.AdminDtos;
using Sillow.BLL.Reponses.AdminResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Contracts
{
    public interface IAdminService : IBaseService
    {
        Task<AdminUpdateResponse> UpdateAdmin(AdminUpdateDto adminUpdateDto);
        Task<AdminDeleteResponse> DeactiveAdmin(AdminDeleteDto adminDeleteDto);
    }
}
