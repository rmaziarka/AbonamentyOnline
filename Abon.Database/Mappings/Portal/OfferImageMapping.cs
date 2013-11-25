using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class OfferImageMapping:MappingBase<OfferImage>
    {
        public OfferImageMapping()
        {

            HasRequired(el => el.Offer)
                .WithMany(el => el.OfferImages)
                .HasForeignKey(el => el.OfferId)
                .WillCascadeOnDelete(false);

            HasRequired(el => el.Image)
                .WithMany(el => el.OfferImages)
                .HasForeignKey(el => el.ImageId)
                .WillCascadeOnDelete(false);
        }
    }
}
