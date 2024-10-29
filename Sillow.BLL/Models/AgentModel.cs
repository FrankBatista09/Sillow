using Sillow.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Models
{
    public class AgentModel : PersonModel
    {
        public string PropertyAmount { get; set; }

        public ICollection<PropertyModel> Properties { get; set; }

        public AgentModel() => PropertyAmount = "0";
    }
}
