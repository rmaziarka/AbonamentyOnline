using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Account
{
    public class ExternalLoginDto
    {
        public string UserName { get; set; }

        public string LoginProvider { get; set; }

        [StringLength(30)]
        [Required]
        public string Name { get; set; }


        [StringLength(250)]
        [Required]
        public string Email { get; set; }
    }


}
