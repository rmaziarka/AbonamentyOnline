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
            Property(m => m.OurPrice);
            Property(m => m.ProducerPrice);
            Property(m => m.OfferType).IsRequired();

            HasOptional(el => el.Image)
                .WithMany(el => el.Offers)
                .HasForeignKey(m => m.ImageId)
                .WillCascadeOnDelete(true);

            HasRequired(el => el.Category)
                .WithMany(el => el.Offers)
                .WillCascadeOnDelete(true);

            HasOptional(el => el.City)
                .WithMany(el => el.Offers)
                .WillCascadeOnDelete(false);
        }
    }
}
