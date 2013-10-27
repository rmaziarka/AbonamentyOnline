using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Database.Model.Portal
{
    public class Image:ModelBase
    {
         public Byte[] FileContent { get; set; }

         public string MimeType { get; set; }

         public ICollection<Category> Categories { get; set; }


         public ICollection<Offer> Offers { get; set; }

    }
}
