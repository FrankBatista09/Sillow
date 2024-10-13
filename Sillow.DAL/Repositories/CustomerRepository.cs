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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SillowContext _sillowcontext;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository (SillowContext sillowcontext, ILogger<CustomerRepository> logger)
        {
            _sillowcontext = sillowcontext;
            _logger = logger;
        }
        public async Task<Customer> Add(Customer entity)
        {
            try
            {
                await _sillowcontext.Customers.AddAsync(entity);
                await _sillowcontext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public Task<Customer> Delete(int id)
        {
            throw new Exception("Delete User is not supported yet");
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                return await _sillowcontext.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Customer> GetById(int id)
        {
            try
            {
                return await _sillowcontext.Customers.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Customer> Update(Customer entity)
        {
            try
            {var existingCustomer = await _sillowcontext.Customers.FindAsync(entity.ID);

            if (existingCustomer == null)
            {
                _logger.LogWarning($"Agent with ID {entity.ID} not found for update.");
                throw new KeyNotFoundException($"Agent with ID {entity.ID} does not exist.");
            }
            existingCustomer.FirstName = entity.FirstName;
            existingCustomer.LastName = entity.LastName;
            existingCustomer.PhoneNumber = entity.PhoneNumber;

            await _sillowcontext.SaveChangesAsync();
                return existingCustomer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
