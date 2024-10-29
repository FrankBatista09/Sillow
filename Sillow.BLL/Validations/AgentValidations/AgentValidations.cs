using Sillow.BLL.Core;
using Sillow.BLL.Dtos.AgentDtos;
using Sillow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Validations.AgentValidations
{
    public class AgentValidations
    {
        private static ServiceResult ValidAgentCommon(AgentUpdateDto agentUpdateDto)
        {
            ServiceResult result = new ServiceResult();

            BaseValidation.AddValidation(agentUpdateDto.FirstName, "The first name for the agent is required");
            BaseValidation.AddValidation(agentUpdateDto.LastName, "The last name for the agent is required");
            BaseValidation.AddValidation(agentUpdateDto.PhoneNumber, "The phone number for the agent is required");

            result = BaseValidation.ProcessValidations(result);
            return result;
        }

        public static async Task<ServiceResult> IsAgentValidToUpdate (AgentUpdateDto agentUpdateDto, IAgentRepository agentRepository)
        {
            ServiceResult result = new();
            result = ValidAgentCommon(agentUpdateDto);

            if (result.Success)
            {
                if (!await agentRepository.Exist(a => a.ID == agentUpdateDto.ID))
                {
                    result.Success = false;
                    result.Message = "The Agent does not exist";
                    return result;
                }

                if(await agentRepository.Exist(a => a.PhoneNumber == agentUpdateDto.PhoneNumber && a.ID != agentUpdateDto.ID))
                {
                    result.Success = false;
                    result.Message = "This phone number is already taken";
                    return result;
                }

                if (!BaseValidation.IsPhoneNumberValid(agentUpdateDto.PhoneNumber))
                {
                    result.Success = false;
                    result.Message = "The phone number forma is not valid";
                    return result;
                }
            }
            return result;
        }
    }
}
