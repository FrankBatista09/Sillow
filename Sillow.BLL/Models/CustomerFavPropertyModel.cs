using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Models
{
    public class CustomerFavPropertyModel
    {
        public int CustomerID { get; set; }
        public CustomerModel Customer { get; set; }

        public int PropertyID { get; set; }
        public PropertyModel Property { get; set; }
    }
}
