using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto.Portal.OfferFolder
{
    public class ImagePathDto
    {
        public Guid Id { get; set; }

        public string Path
        {
            get
            {
                return "File/GetImage?id=" + Id;
            }
        }
    }
}
