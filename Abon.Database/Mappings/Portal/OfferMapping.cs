using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class OfferMapping:MappingBase<Offer>
    {
        public OfferMapping()
        {
            Property(m => m.Description).IsRequired();
            Property(m => m.Name).IsRequired().HasMaxLength(255);
            Property(m => m.OfferImageUrl).IsRequired();
            Property(m => m.CompanyLogoUrl).IsRequired();
            Property(m => m.OurPrice);
            Property(m => m.ProducerPrice);


            HasRequired(el => el.Category)
                .WithMany(el => el.Offers)
                .WillCascadeOnDelete(true);
        }
    }
}
