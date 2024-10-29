using Microsoft.Extensions.Logging;
using Sillow.BLL.Contracts;
using Sillow.BLL.Core;
using Sillow.BLL.Dtos.AdminDtos;
using Sillow.BLL.Reponses.AdminResponses;
using Sillow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly ILogger<AdminService> _logger;

        public AdminService(IAdminRepository adminRepository, ILogger<AdminService> logger)
        {
            _adminRepository = adminRepository;
            _logger = logger;
        }

        public Task<AdminDeleteResponse> DeactiveAdmin(AdminDeleteDto adminDeleteDto)
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

        public Task<AdminUpdateResponse> UpdateAdmin(AdminUpdateDto adminUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
