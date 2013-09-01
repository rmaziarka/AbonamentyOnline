using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class UserLoginMapping:MappingBase<UserLogin>
    {
        public UserLoginMapping()
        {
            Property(m => m.LoginProvider).IsRequired();
            Property(m => m.ProviderKey).IsRequired();

            HasRequired(m => m.User)
                .WithMany(m => m.UserLogins)
                .HasForeignKey(m => m.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}
