using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class UserMapping:MappingBase<User>
    {
        public UserMapping()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(30);

        }
    }
}
