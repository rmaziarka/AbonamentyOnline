using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class CompanyMapping:MappingBase<Company>
    {
        public CompanyMapping()
        {
            Property(m => m.Description).IsRequired();
            Property(m => m.Email).IsRequired().HasMaxLength(250);
            Property(m => m.Name).IsRequired().HasMaxLength(60);
            Property(m => m.Nip).IsRequired().HasMaxLength(30);
            Property(m => m.Phone).IsRequired().HasMaxLength(30);
            Property(m => m.Regon).IsRequired().HasMaxLength(30);

            HasRequired(m => m.Address)
                .WithMany(m => m.CompaniesByAddress)
                .HasForeignKey(m => m.AddressId)
                .WillCascadeOnDelete(false);

            HasOptional(m => m.ContactAddress)
                .WithMany(m => m.CompaniesByContactAddress)
                .HasForeignKey(m => m.ContactAddressId)
                .WillCascadeOnDelete(false);

            HasRequired(m => m.Logo)
                .WithMany(m => m.Companies)
                .HasForeignKey(m => m.LogoId)
                .WillCascadeOnDelete(false);
        }
    }
}
