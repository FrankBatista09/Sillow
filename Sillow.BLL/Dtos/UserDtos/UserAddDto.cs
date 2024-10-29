using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Dtos.UserDtos
{
    public class UserAddDto
    {
        [Required(ErrorMessage = "The first name of the user is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name of the user is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email of the user is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The phone number of the user is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The sex of the user is required")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "The Username of the user is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password of the user is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Role of the user is required")]
        public string Role { get; set; }
    }
}
