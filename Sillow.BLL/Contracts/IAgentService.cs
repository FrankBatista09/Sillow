using Sillow.BLL.Core;
using Sillow.BLL.Dtos.AgentDtos;
using Sillow.BLL.Reponses.AgentResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Contracts
{
    public interface IAgentService : IBaseService
    {
        Task<AgentUpdateResponse> UpdateAgent(AgentUpdateDto agentUpdateDto);
    }
}
