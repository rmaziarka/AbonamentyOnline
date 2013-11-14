using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class AddressMapping:MappingBase<Address>
    {
        public AddressMapping()
        {
            Property(m => m.Street).IsRequired().HasMaxLength(30);
            Property(m => m.LocalNumber).IsOptional().HasMaxLength(30);
            Property(m => m.StreetNumber).IsRequired().HasMaxLength(30);
            Property(m => m.CityName).IsRequired().HasMaxLength(30);
            Property(m => m.PostCode).IsRequired().HasMaxLength(30);
        }
    }
}
