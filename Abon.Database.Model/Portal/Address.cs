using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Database.Model.Portal
{
    public class Address:ModelBase
    {
        public string Street { get; set; }

        public string LocalNumber { get; set; }

        public string StreetNumber { get; set; }

        public string CityName { get; set; }

        public string PostCode { get; set; }

        public virtual ICollection<Company> CompaniesByAddress { get; set; }

        public virtual ICollection<Company> CompaniesByContactAddress { get; set; }


    }
}
