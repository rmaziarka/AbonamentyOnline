using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal.Enums;

namespace Abon.Database.Model.Portal
{
    public class Category:ModelBase
    {
        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public CategoryType CategoryType { get; set; }

        public int Left { get; set; }

        public int Right { get; set; }

        public Guid? ImageId {get; set; }
        public Image Image { get; set; }

        public ICollection<Category> Children { get; set; }
 
        public Category Parent { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
