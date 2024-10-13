using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sillow.DAL.Context;
using Sillow.DAL.Entities;
using Sillow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.DAL.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly SillowContext _sillowcontext;
        private readonly ILogger<AdminRepository> _logger;

        public AdminRepository(SillowContext sillowcontext, ILogger<AdminRepository> logger)
        {
            _sillowcontext = sillowcontext;
            _logger = logger;
        }
        public async Task<Admin> Add(Admin entity)
        {
            try
            {
                await _sillowcontext.Admins.AddAsync(entity);
                await _sillowcontext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }

        public async Task<Admin> Delete(int id)
        {
            try
            {
                var admin = await _sillowcontext.Admins.FindAsync(id);
                if (admin != null)
                {
                    admin.IsActive = false;
                    await _sillowcontext.SaveChangesAsync();
                }
                return admin;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            try 
            {
                return await _sillowcontext.Admins
                    .Where(admin => admin.IsActive).ToListAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Admin> GetById(int id)
        {
            try
            {
                return await _sillowcontext.Admins
                    .FirstOrDefaultAsync(admin => admin.ID == id && admin.IsActive);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public Task<Admin> Update(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
