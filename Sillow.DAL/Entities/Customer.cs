using Sillow.DAL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.DAL.Entities
{
    public class Customer : Person
    {
        public ICollection<CustomerFavProperty> FavProperties { get; set; }
        public ICollection<CustomerSoldProperty> SoldProperties { get; set; }

    }
}
