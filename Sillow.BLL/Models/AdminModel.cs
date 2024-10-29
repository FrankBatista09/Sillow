using Sillow.BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.BLL.Models
{
    public class AdminModel : PersonModel
    {
        public bool IsActive { get; set; }

        public AdminModel() => IsActive = true;
    }
}
