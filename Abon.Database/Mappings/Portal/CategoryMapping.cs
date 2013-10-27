using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class CategoryMapping:MappingBase<Category>
    {
        public CategoryMapping()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(255);
            Property(m => m.ParentId).IsOptional();
            Property(m => m.CategoryType).IsRequired();
            Property(m => m.Left).IsRequired();
            Property(m => m.Right).IsRequired();

            HasOptional(el => el.Image)
                .WithMany(el => el.Categories)
                .HasForeignKey(m => m.ImageId)
                .WillCascadeOnDelete(false);

            HasOptional(el => el.Parent)
                .WithMany(el => el.Children)
                .HasForeignKey(m => m.ParentId)
                .WillCascadeOnDelete(false);
        }
    }
}
