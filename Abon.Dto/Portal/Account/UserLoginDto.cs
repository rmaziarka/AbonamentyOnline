using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Account
{
    public class UserLoginDto
    {
        public string NameOrEmail { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
