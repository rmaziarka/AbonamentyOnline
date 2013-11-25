using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Database.Model.Portal
{
    public class OfferImage:ModelBase
    {
        public System.Guid Id { get; set; }
        public System.Guid OfferId { get; set; }
        public System.Guid ImageId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
