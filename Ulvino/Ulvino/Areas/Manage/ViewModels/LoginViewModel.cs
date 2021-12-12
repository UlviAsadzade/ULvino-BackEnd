using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Areas.Manage.ViewModels
{
    public class LoginViewModel
    {
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "UserName can be min 6, max 50 ")]
        public string UserName { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 6, ErrorMessage = "Password can be min 6, max 30")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPersistent { get; set; } = false;
    }
}
