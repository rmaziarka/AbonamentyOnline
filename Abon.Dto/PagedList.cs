using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto
{
    public class PagedList<T> 
    {
        public int Total { get; set; }

        public int Page { get; set; }

        public int Take { get; set; }

        public IEnumerable<T> List { get; set; } 
    }
}
