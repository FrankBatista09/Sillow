using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Core
{
    public class PersonModel
    {
        public int ID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Sex { get; set; }
        public DateTime CreatedDate { get; set; }

        public PersonModel() => CreatedDate = DateTime.Now;
    }
}
