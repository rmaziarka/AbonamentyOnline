using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Core.Helpers
{
    public static class StringHelper
    {
        public static string FirstLower(this string s)
        {
            return Char.ToLowerInvariant(s[0]) + s.Substring(1);
        }
    }
}
