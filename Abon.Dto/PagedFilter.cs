using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Dto
{
    public class PagedFilter
    {
        public PagedFilter()
        {
            Page = 1;
            Take = 5;
        }

        public int Page { get; set; }

        public int Take { get; set; }

        public int Skip
        {
            get
            {
                return (Page - 1) * Take;
            }
        }
    }
}
