using Microsoft.Extensions.Logging;
using Sillow.BLL.Contracts;
using Sillow.BLL.Core;
using Sillow.BLL.Dtos.AgentDtos;
using Sillow.BLL.Reponses.AgentResponses;
using Sillow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Services
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;
        private readonly ILogger<AgentService> _logger;

        private AgentService(IAgentRepository agentRepository, ILogger<AgentService> logger)
        {
            _agentRepository = agentRepository;
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

        public Task<AgentUpdateResponse> UpdateAgent(AgentUpdateDto agentUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
