using Sillow.DAL.Core;
using Sillow.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.DAL.Entities
{
    public class Agent : Person
    {
        public string PropertyAmount { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
    
}

