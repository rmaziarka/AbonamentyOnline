using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Database.Model.Portal
{
    public class City:ModelBase
    {
        public string Name { get; set; }

        public ICollection<Offer> Offers { get; set; }
    }
}
