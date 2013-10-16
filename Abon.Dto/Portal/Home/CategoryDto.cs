using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal.Enums;

namespace Abon.Dto.Portal.Home
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public CategoryDto Parent { get; set; }

        public Guid? ParentId { get; set; }

        public IEnumerable<CategoryDto> Children { get; set; }

        public string Name { get; set; }

        public CategoryType CategoryType { get; set; }

        public int OffersNumber { get; set; }
    }
}
