using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class OfferMapping:MappingBase<Offer>
    {
        public OfferMapping()
        {
            Property(m => m.Description).IsRequired();
            Property(m => m.Name).IsRequired().HasMaxLength(255);
            Property(m => m.OurPrice);
            Property(m => m.ProducerPrice);
            Property(m => m.OfferType).IsRequired();


            HasRequired(el => el.Company)
                .WithMany(el => el.Offers)
                .HasForeignKey(el => el.CompanyId)
                .WillCascadeOnDelete(true);

            HasOptional(el => el.Image)
                .WithMany(el => el.OffersByImage)
                .HasForeignKey(m => m.ImageId)
                .WillCascadeOnDelete(true);

            HasOptional(el => el.CompanyLogo)
                .WithMany(el => el.OffersByCompanyLogo)
                .HasForeignKey(m => m.CompanyLogoId)
                .WillCascadeOnDelete(false);


            HasRequired(el => el.Category)
                .WithMany(el => el.Offers)
                .HasForeignKey(m => m.CategoryId)
                .WillCascadeOnDelete(true);

            HasOptional(el => el.City)
                .WithMany(el => el.Offers)
                .HasForeignKey(m => m.CityId)
                .WillCascadeOnDelete(false);
        }
    }
}
