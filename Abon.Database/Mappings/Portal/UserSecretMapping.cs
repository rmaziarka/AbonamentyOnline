using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class UserSecretMapping:MappingBase<UserSecret>
    {
        public UserSecretMapping()
        {
            Property(m => m.Salt).IsRequired();
            Property(m => m.Hash).IsRequired();

            HasRequired(el => el.User)
                .WithOptional(el => el.UserSecret)
                .WillCascadeOnDelete(true);

        }
    }
}
