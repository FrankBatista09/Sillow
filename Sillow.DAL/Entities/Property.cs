using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.DAL.Entities
{
    public class Property
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string PropertyType { get; set; }
        public required string SaleType { get; set; }
        public required string Price { get; set; }
        public required string Size { get; set; }
        public required int RoomAmount { get; set; }
        public required int BathroomAmount { get; set; }
        public required string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int AgentID { get; set; }
        public Agent Agent { get; set; }

        public ICollection<CustomerFavProperty> FavProperties { get; set; }
        public ICollection<CustomerSoldProperty> SoldProperties { get; set; }

        public Property()
        {
            IsActive = true;
            IsDeleted = false;
        }
    }
}
