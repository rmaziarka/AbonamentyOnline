using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal;
using Abon.Database.Model.Portal.Enums;

namespace Abon.Database.Initializers.Portal
{
    public class OfferInitializer:IDbInitializer<Offer>
    {
        public List<Offer> Initialize()
        {
            return new List<Offer>()
                {
                    new Offer
                        {
                            Id = Guid.Parse("349b9df2-3c1c-41cd-94d2-fb9336bd0b27"),
                            Name = "Abonament telefoniczny Play",
                            Description = "Super fajny abonament Play. Musisz nas kupić",
                            ProducerPrice = 50,
                            OurPrice = 40,
                            CategoryId = Guid.Parse("BA36C7B2-DBC5-4D14-9A42-1436402357D2"),
                            CompanyId = Guid.Parse("75326404-d874-400d-8723-b4eaa62b0d68"),
                            LogoId =  Guid.Parse("6aee9e1d-59d4-4f3e-b08a-afc0cbb7f0ae"),
                            CreateDate = DateTime.Now,
                            CityId = Guid.Parse("a5a82340-25a8-4c26-932a-c646ec534d62"),
                            OfferType = OfferType.Individual
                        },

                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Abonament telefoniczny Orange",
                            Description = "Ten abonament jest lepszy niż każdy inny. Nie mieć go to jak nie oddychać.",
                            ProducerPrice = 100,
                            OurPrice = 80,
                            CategoryId = Guid.Parse("BA36C7B2-DBC5-4D14-9A42-1436402357D2"),
                            CompanyId = Guid.Parse("75326404-d874-400d-8723-b4eaa62b0d68"),
                            LogoId =  Guid.Parse("6aee9e1d-59d4-4f3e-b08a-afc0cbb7f0ae"),
                            CreateDate = DateTime.Now,
                            OfferType = OfferType.Individual
                        },

                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Obiady w Poranna Rosa",
                            Description = "Kup abonament na nasze obiady już dzisiaj. Jutro możesz być głody i gdzie zjesz?",
                            ProducerPrice = 200,
                            OurPrice = 170,
                            CategoryId = Guid.Parse("DB0969F1-A8DA-4253-9E40-1B4CE6E67C08") ,
                            CompanyId = Guid.Parse("75326404-d874-400d-8723-b4eaa62b0d68"),
                            LogoId =  Guid.Parse("6aee9e1d-59d4-4f3e-b08a-afc0cbb7f0ae"),
                            CreateDate = DateTime.Now,
                            CityId = Guid.Parse("571bc239-d6ac-411a-ab0b-62ddb3f4ad4d"),
                            OfferType = OfferType.Individual
                        },

                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Karnet na siłownię w Fitness Academy",
                            Description = "Forma musi być. Na coś laski muszą lecieć. Zapisz się jeszcze dzisiaj.",
                            ProducerPrice = 150,
                            OurPrice = 130,
                            CategoryId = Guid.Parse("4A666C07-80B3-470C-BDDD-06B12B0D9D4C"),
                            CompanyId = Guid.Parse("75326404-d874-400d-8723-b4eaa62b0d68"),
                            LogoId =  Guid.Parse("6aee9e1d-59d4-4f3e-b08a-afc0cbb7f0ae"),
                            CreateDate = DateTime.Now,
                            OfferType = OfferType.Individual
                        },

                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Siłownia Klawy John na 3 miesiące",
                            Description = "Dzisiejsza walka o lepszą formę to jutrzejsza większość ilość ruchania. Nie czekaj dłużej",
                            ProducerPrice = 180,
                            OurPrice = 120,
                            CategoryId = Guid.Parse("4A666C07-80B3-470C-BDDD-06B12B0D9D4C"),
                            CompanyId = Guid.Parse("75326404-d874-400d-8723-b4eaa62b0d68"),
                            LogoId =  Guid.Parse("6aee9e1d-59d4-4f3e-b08a-afc0cbb7f0ae"),
                            CreateDate = DateTime.Now,
                            OfferType = OfferType.Individual
                        },
                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Aurora Fitness Club",
                            Description = "Zapisz się już dziś by uzyskać upust na nasze SPA.",
                            ProducerPrice = 150,
                            OurPrice = 130,
                            CategoryId = Guid.Parse("4A666C07-80B3-470C-BDDD-06B12B0D9D4C"),
                            CompanyId = Guid.Parse("75326404-d874-400d-8723-b4eaa62b0d68"),
                            LogoId =  Guid.Parse("6aee9e1d-59d4-4f3e-b08a-afc0cbb7f0ae"),
                            CreateDate = DateTime.Now,
                            OfferType = OfferType.Individual
                        },
                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Pizza Roma codziennie",
                            Description = "Coś dla prawdziwych geeków. Codziennie pizza by być zawsze pełen energii.",
                            ProducerPrice = 200,
                            OurPrice = 170,
                            CategoryId = Guid.Parse("DB0969F1-A8DA-4253-9E40-1B4CE6E67C08") ,
                            CompanyId = Guid.Parse("75326404-d874-400d-8723-b4eaa62b0d68"),
                            LogoId =  Guid.Parse("6aee9e1d-59d4-4f3e-b08a-afc0cbb7f0ae"),
                            CreateDate = DateTime.Now,
                            CityId = Guid.Parse("571bc239-d6ac-411a-ab0b-62ddb3f4ad4d"),
                            OfferType = OfferType.Individual
                        },

                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Dinette zaprasza",
                            Description = "Bistro Dinette zaprasza na codzienny lunch.",
                            ProducerPrice = 200,
                            OurPrice = 170,
                            CategoryId = Guid.Parse("DB0969F1-A8DA-4253-9E40-1B4CE6E67C08") ,
                            CompanyId = Guid.Parse("75326404-d874-400d-8723-b4eaa62b0d68"),
                            LogoId =  Guid.Parse("6aee9e1d-59d4-4f3e-b08a-afc0cbb7f0ae"),
                            CreateDate = DateTime.Now,
                            CityId = Guid.Parse("571bc239-d6ac-411a-ab0b-62ddb3f4ad4d"),
                            OfferType = OfferType.Business
                        },
                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Abonament telefoniczny Orange",
                            Description = "Orange dalej ma chujowe oferty ale i tak się tutaj znalazło.",
                            ProducerPrice = 50,
                            OurPrice = 40,
                            CategoryId = Guid.Parse("BA36C7B2-DBC5-4D14-9A42-1436402357D2"),
                            CompanyId = Guid.Parse("75326404-d874-400d-8723-b4eaa62b0d68"),
                            LogoId =  Guid.Parse("6aee9e1d-59d4-4f3e-b08a-afc0cbb7f0ae"),
                            CreateDate = DateTime.Now,
                            CityId = Guid.Parse("a5a82340-25a8-4c26-932a-c646ec534d62"),
                            OfferType = OfferType.Business
                        },
                };
        }
    }
}
