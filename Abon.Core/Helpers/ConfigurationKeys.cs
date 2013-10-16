using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Abon.Core.Helpers
{
    public static class ConfigurationKeys
    {
        public static bool MockServices
        {
            get
            {
                var s = WebConfigurationManager.AppSettings["PFUserName"];
                bool value;
                var isBool = Boolean.TryParse(s, out value);

                return isBool ? value : false;
            }
        }

    }
}
