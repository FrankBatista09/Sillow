using Sillow.BLL.Core;
using Sillow.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Models
{
    public class CustomerModel : PersonModel
    {
        public ICollection<CustomerFavProperty> FavProperties { get; set; }
        public ICollection<CustomerSoldProperty> SoldProperties { get; set; }
    }
}
