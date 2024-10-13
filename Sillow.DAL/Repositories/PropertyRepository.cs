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
    public class PropertyRepository : IPropertyRepository
    {
        private readonly SillowContext _sillowcontext;
        private ILogger<PropertyRepository> _logger;

        public PropertyRepository(SillowContext sillowcontext, ILogger<PropertyRepository> logger)
        {
            _sillowcontext = sillowcontext;
            _logger = logger;
        }
        public async Task<Property> Add(Property entity)
        {
            try
            {
                await _sillowcontext.Properties.AddAsync(entity);
                await _sillowcontext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Property> Delete(int id)
        {
            try
            {
                var admin = await _sillowcontext.Properties.FindAsync(id);
                
                if (admin != null)
                {
                    admin.IsDeleted = true;
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

        public async Task<IEnumerable<Property>> GetAll()
        {
            try
            {
                return await _sillowcontext.Properties
                    .Where(property => !property.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Property> GetById(int id)
        {
            try
            {
                return await _sillowcontext.Properties
                    .FirstOrDefaultAsync(property => property.Id == id && !property.IsDeleted);    
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<Property> Update(Property entity)
        {
            try
            {
                var existingProperty = await _sillowcontext.Properties.FindAsync(entity.Id);

                if (existingProperty == null)
                {
                    _logger.LogWarning($"Property with ID {entity.Id} not found for update.");
                    throw new KeyNotFoundException($"Agent with ID {entity.Id} does not exist.");
                }

                existingProperty.PropertyType = entity.PropertyType;
                existingProperty.SaleType = entity.SaleType;
                existingProperty.Price = entity.Price;
                existingProperty.Size = entity.Size;
                existingProperty.RoomAmount = entity.RoomAmount;
                existingProperty.BathroomAmount = entity.BathroomAmount;
                existingProperty.Description = entity.Description;

                await _sillowcontext.SaveChangesAsync();
                return existingProperty;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
