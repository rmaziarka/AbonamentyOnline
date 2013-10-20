using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class CityMapping:MappingBase<City>
    {
        public CityMapping()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(255);
        }
    }
}
