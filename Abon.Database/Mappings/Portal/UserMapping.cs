using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class UserMapping:MappingBase<User>
    {   
        public UserMapping()    
        {
            Property(m => m.Name).IsRequired().HasMaxLength(30);
            Property(m => m.Email).IsRequired().HasMaxLength(250);
            Property(m => m.Phone).IsOptional().HasMaxLength(30);
            Property(m => m.FirstName).IsOptional().HasMaxLength(30);
            Property(m => m.SecondName).IsOptional().HasMaxLength(30);
        }
    }
}
