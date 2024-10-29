using Sillow.BLL.Core;
using Sillow.BLL.Dtos.UserDtos;
using Sillow.BLL.Reponses.UserResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Contracts
{
    public interface IUserService : IBaseService
    {
        Task<UserAddResponse> AddUserAsync (UserAddDto userAddDto);
        Task<UserUpdateResponse> UpdateUser(UserUpdateDto userUpdateDto);

    }
}
