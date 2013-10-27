using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.Home
{
    public class ImageDto
    {
        public Guid Id { get; set; }

        public Byte[] FileContent { get; set; }

        public string MimeType { get; set; }

    }
}
