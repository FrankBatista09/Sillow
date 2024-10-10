using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.DAL.Entities
{
    public class CustomerSoldProperty
    {

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int PropertyID { get; set; }
        public Property Property { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public CustomerSoldProperty() => CreatedDate = DateTime.Now;


    }
}
