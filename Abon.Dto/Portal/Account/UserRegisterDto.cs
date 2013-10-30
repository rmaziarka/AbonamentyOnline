using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Account
{
    public class UserRegisterDto
    {
        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        [StringLength(30)]
        [Required]
        public string Password { get; set; }

        [StringLength(30)]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [StringLength(250)]
        [Required]
        public string Email { get; set; }
    }
}
