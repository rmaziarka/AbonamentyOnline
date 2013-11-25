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

         public virtual ICollection<Category> Categories { get; set; }

         public virtual ICollection<Offer> OffersByImage { get; set; }

         public virtual ICollection<Offer> OffersByCompanyLogo { get; set; }

         public virtual ICollection<Company> Companies { get; set; }

         public virtual ICollection<OfferImage> OfferImages { get; set; }
    }
}
