using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Dtos.PropertyDtos
{
    public class PropertyUpdateDto
    {
        [Required(ErrorMessage = "The Property type of the property is required")]
        public required string PropertyType { get; set; }

        [Required(ErrorMessage = "The Sale type of the property is required")]
        public required string SaleType { get; set; }

        [Required(ErrorMessage = "The price of the property is required")]
        public required string Price { get; set; }

        [Required(ErrorMessage = "The size of the property is required")]
        public required string Size { get; set; }

        [Required(ErrorMessage = "The amount of rooms of the property is required")]
        public required int RoomAmount { get; set; }

        [Required(ErrorMessage = "The bathroom amount of the property is required")]
        public required int BathroomAmount { get; set; }

        [Required(ErrorMessage = "The description of the property is required")]
        public required string Description { get; set; }
    }
}
