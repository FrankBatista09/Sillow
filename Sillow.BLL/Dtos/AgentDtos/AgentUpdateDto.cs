using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Dtos.AgentDtos
{
    public class AgentUpdateDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The first name of the agent is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name of the agent is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The phone number of the agent is required")]
        public string PhoneNumber { get; set; }
    }
}
