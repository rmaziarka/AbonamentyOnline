using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal;

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
                            Id = Guid.NewGuid(),
                            Name = "Abonament telefoniczny Play",
                            Description = "Super fajny abonament Play. Musisz nas kupić",
                            ProducerPrice = 50,
                            OurPrice = 40,
                            CategoryId = Guid.Parse("BA36C7B2-DBC5-4D14-9A42-1436402357D2"),
                            CompanyLogoUrl = "",
                            OfferImageUrl = "",
                            CreateDate = DateTime.Now
                        },

                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Abonament telefoniczny Orange",
                            Description = "Ten abonament jest lepszy niż każdy inny. Nie mieć go to jak nie oddychać.",
                            ProducerPrice = 100,
                            OurPrice = 80,
                            CategoryId = Guid.Parse("BA36C7B2-DBC5-4D14-9A42-1436402357D2"),
                            CompanyLogoUrl = "",
                            OfferImageUrl = "",
                            CreateDate = DateTime.Now
                        },

                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Obiady w Poranna Rosa",
                            Description = "Kup abonament na nasze obiady już dzisiaj. Jutro możesz być głody i gdzie zjesz?",
                            ProducerPrice = 200,
                            OurPrice = 170,
                            CategoryId = Guid.Parse("DB0969F1-A8DA-4253-9E40-1B4CE6E67C08") ,
                            CompanyLogoUrl = "",
                            OfferImageUrl = "",
                            CreateDate = DateTime.Now
                        },

                    new Offer
                        {
                            Id = Guid.NewGuid(),
                            Name = "Karnet na siłownię w Fitness Academy",
                            Description = "Forma musi być. Na coś laski muszą lecieć. Zapisz się jeszcze dzisiaj.",
                            ProducerPrice = 150,
                            OurPrice = 130,
                            CategoryId = Guid.Parse("4A666C07-80B3-470C-BDDD-06B12B0D9D4C"),
                            CompanyLogoUrl = "",
                            OfferImageUrl = "",
                            CreateDate = DateTime.Now
                        },

                };
        }
    }
}
