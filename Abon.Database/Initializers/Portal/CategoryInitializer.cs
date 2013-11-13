using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal;
using Abon.Database.Model.Portal.Enums;
using Abon.Database.Helpers;

namespace Abon.Database.Initializers.Portal
{
    public class CategoryInitializer : IDbInitializer<Category>
    {
        public List<Category> Initialize()
        {

            var main = new Category
                        {
                            Id = Guid.Empty,
                            Name = "Główna",
                            CategoryType = CategoryType.Both,
                            Children = GetMainCategories()
                        };

            var helper = new CategoryRangeSetter();
            helper.SetCategoriesRange(main);

            return new List<Category>{
                main
            };



        }


        private List<Category> GetMainCategories()
        {
            return new List<Category>()
                {
                        
                    new Category
                        {
                            Id= Guid.Parse("BA36C7B2-DBC5-4D14-9A42-1436402357D2") ,
                            Name = "Telefony",
                            CategoryType = CategoryType.Both,
                            Children = GetPhoneChildren(),
                            ImageId = Guid.Parse("02313c5a-cc01-4ce5-96a1-0609196c3515")

                        },
                    new Category
                        {
                            Id= Guid.Parse("DB0969F1-A8DA-4253-9E40-1B4CE6E67C08") ,
                            Name = "Jedzenie",
                            CategoryType = CategoryType.Both,
                            Children = GetFoodChildren(),
                            ImageId = Guid.Parse("2269152f-9a6b-4023-8009-b57038aefd57")
                        },
                    new Category
                        {
                            Id= Guid.Parse("4A666C07-80B3-470C-BDDD-06B12B0D9D4C") ,
                            Name = "Rozrywka",
                            CategoryType = CategoryType.Both,
                            Children = GetEntertainmentChildren(),
                            ImageId = Guid.Parse("02313c5a-cc01-4ce5-96a1-0609196c3515")
                        },
                          new Category
                        {
                            Id= Guid.Parse("e6c8e98b-f754-4bf3-a038-f1aec0e1a29b") ,
                            Name = "Prenumeraty",
                            CategoryType = CategoryType.Both,
                            Children = GetPrenumerationChildren(),
                            ImageId = Guid.Parse("2269152f-9a6b-4023-8009-b57038aefd57")
                        },

                };
        }


        private List<Category> GetPhoneChildren(){
            return new List<Category>()
                {
                    new Category
                        {
                            Id= Guid.Parse("15836799-722e-4dba-a38b-8d37fcc6b329") ,
                            Name = "Abonamenty",
                            CategoryType = CategoryType.Both
                        },
                    new Category
                        {
                            Id= Guid.Parse("fd61085f-798b-44b7-947e-3830b0bb2d01") ,
                            Name = "Mix",
                            CategoryType = CategoryType.Individual
                        },
                    new Category
                        {
                            Id= Guid.Parse("26b44e53-7558-4fef-81c3-713540e41e27") ,
                            Name = "Sam telefon",
                            CategoryType = CategoryType.Business
                        },

                };      
        }

        private List<Category> GetFoodChildren()
        {
            return new List<Category>()
                {
                    new Category
                        {
                            Id= Guid.Parse("e2347316-bb9e-452c-8ca0-916d52484e4c") ,
                            Name = "Sushi",
                            CategoryType = CategoryType.Business
                        },
                    new Category
                        {
                            Id= Guid.Parse("945c1aa0-a909-4f9e-99f5-af64d30c75ed") ,
                            Name = "Pizza",
                            CategoryType = CategoryType.Business
                        },
                    new Category
                        {
                            Id= Guid.Parse("70b7271b-1184-4dea-af07-f34bf58794bc") ,
                            Name = "Meksykańska",
                            CategoryType = CategoryType.Both
                        },

                };      
        }

        private List<Category> GetEntertainmentChildren()
        {
            return new List<Category>()
                {
                    new Category
                        {
                            Id= Guid.Parse("cf8557f8-8864-4ca1-a8be-3b7c656a8cd8") ,
                            Name = "Siłownia",
                            CategoryType = CategoryType.Business
                        },
                    new Category
                        {
                            Id= Guid.Parse("8df58b97-227a-49d3-b5e4-7e31ef5d1485") ,
                            Name = "Kręgle",
                            CategoryType = CategoryType.Business
                        },
                    new Category
                        {
                            Id= Guid.Parse("3fd039b0-ea5d-49cc-821c-e6672fb2283d") ,
                            Name = "Bilard",
                            CategoryType = CategoryType.Both
                        },

                };
        }

        private List<Category> GetPrenumerationChildren()
        {
            return new List<Category>()
                {
                    new Category
                        {
                            Id= Guid.Parse("6305d7d8-c569-44a9-ab7a-f0a7d2637743") ,
                            Name = "Gazety",
                            CategoryType = CategoryType.Business
                        }

                };
        }
    }
}
