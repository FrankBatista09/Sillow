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
    public class AgentRepository : IAgentRepository
    {
        private readonly SillowContext _sillowcontext;
        private readonly ILogger<AgentRepository> _logger;

        public AgentRepository(SillowContext sillowcontext, ILogger<AgentRepository> logger)
        {
            _sillowcontext = sillowcontext;
            _logger = logger;
        }
        public async Task<Agent> Add(Agent entity)
        {
            try
            {
                await _sillowcontext.Agents.AddAsync(entity);
                await _sillowcontext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Agent> Delete(int id)
        {
            throw new Exception("Delete User is not supported yet");
        }

        public async Task<IEnumerable<Agent>> GetAll()
        {
            try
            {
                return await _sillowcontext.Agents.ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Agent> GetById(int id)
        {
            try
            {
                return await _sillowcontext.Agents.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Agent> Update(Agent entity)
        {
            try
            {
                var existingAgent = await _sillowcontext.Agents.FindAsync(entity.ID);

                if (existingAgent == null)
                {
                    _logger.LogWarning($"Agent with ID {entity.ID} not found for update.");
                    throw new KeyNotFoundException($"Agent with ID {entity.ID} does not exist.");
                }

                existingAgent.FirstName = entity.FirstName;
                existingAgent.LastName = entity.LastName;
                existingAgent.PhoneNumber = entity.PhoneNumber;
                existingAgent.PropertyAmount = entity.PropertyAmount;

                await _sillowcontext.SaveChangesAsync();
                return existingAgent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
