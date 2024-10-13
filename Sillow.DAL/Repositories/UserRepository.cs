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
    public class UserRepository : IUserRepository
    {
        private readonly SillowContext _sillowcontext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(SillowContext sillowcontext, ILogger<UserRepository> logger)
        {
             _sillowcontext = sillowcontext;
            _logger = logger;
        }
        public async Task<User> Add(User entity)
        {
            try
            {
                // Primero, agrega el usuario en la tabla de Users
                await _sillowcontext.Users.AddAsync(entity);

                // Ahora, crea una entidad específica según el rol
                switch (entity.Role)
                {
                    case "Admin":
                        var admin = new Admin
                        {
                            // Asigna los campos compartidos
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Email = entity.Email,
                            PhoneNumber = entity.PhoneNumber,
                            Sex = entity.Sex,
                            CreatedDate = entity.CreatedDate
                        };
                        await _sillowcontext.Admins.AddAsync(admin);
                        break;

                    case "Agent":
                        var agent = new Agent
                        {
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Email = entity.Email,
                            PhoneNumber = entity.PhoneNumber,
                            Sex = entity.Sex,
                            CreatedDate = entity.CreatedDate
                        };
                        await _sillowcontext.Agents.AddAsync(agent);
                        break;

                    case "Customer":
                        var customer = new Customer
                        {
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Email = entity.Email,
                            PhoneNumber = entity.PhoneNumber,
                            Sex = entity.Sex,
                            CreatedDate = entity.CreatedDate
                        };
                        await _sillowcontext.Customers.AddAsync(customer);
                        break;

                    default:
                        throw new ArgumentException("Invalid role");
                }

                await _sillowcontext.SaveChangesAsync();
                return entity;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Failed to add user with role {entity.Role}: {ex.Message}");
                throw;
            }
        }

        public Task<User> Delete(int id)
        {
            throw new Exception("Delete User is not supported yet");
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _sillowcontext.Users.ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                return await _sillowcontext.Users.FindAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<User> Update(User entity)
        {
            try
            {
                var existingUser = await _sillowcontext.Users.FindAsync(entity.ID);

                if (existingUser == null)
                {
                    _logger.LogWarning($"User with ID {entity.ID} not found for update.");
                    throw new KeyNotFoundException($"Agent with ID {entity.ID} does not exist.");
                }
                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.PhoneNumber = entity.PhoneNumber;

                await _sillowcontext.SaveChangesAsync();
                return existingUser;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
