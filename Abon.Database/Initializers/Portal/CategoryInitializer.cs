using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal;
using Abon.Database.Model.Portal.Enums;

namespace Abon.Database.Initializers.Portal
{
    public class CategoryInitializer:IDbInitializer<Category>
    {
        public List<Category> Initialize()
        {
            return  new List<Category>()
                {
                    new Category
                        {
                            Id= Guid.Empty ,
                            Name = "Główna",
                            Left = 1,
                            Right = 8,
                            CategoryType = CategoryType.Both
                        },
                        
                    new Category
                        {
                            Id= Guid.Parse("BA36C7B2-DBC5-4D14-9A42-1436402357D2") ,
                            Name = "Telefony",
                            Left = 2,
                            Right=3,
                            CategoryType = CategoryType.Both,
                            ParentId = Guid.Empty
                        },
                    new Category
                        {
                            Id= Guid.Parse("DB0969F1-A8DA-4253-9E40-1B4CE6E67C08") ,
                            Name = "Jedzenie",
                            Left = 4,
                            Right=5,
                            CategoryType = CategoryType.Both,
                            ParentId = Guid.Empty
                        },
                    new Category
                        {
                            Id= Guid.Parse("4A666C07-80B3-470C-BDDD-06B12B0D9D4C") ,
                            Name = "Trzecia",
                            Left = 6,
                            Right=7,
                            CategoryType = CategoryType.Both,
                            ParentId = Guid.Empty
                        }

                };
        }
    }
}
