using Abon.Database.Model.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Database.Helpers
{
    public class CategoryRangeSetter
    {
        public void SetCategoriesRange(Category main)
        {
            int i = 1;
            SetRange(main, ref i);
        }

        private void SetRange(Category main, ref int number)
        {
            main.Left = number;
            number++;

            if (main.Children != null)
                foreach (var child in main.Children)
                    SetRange(child, ref number);

            main.Right = number;
            number++;
        }

    }
}
