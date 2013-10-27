using Abon.Database.Model.Portal;

namespace Abon.Database.Mappings.Portal
{
    public class ImageMapping:MappingBase<Image>
    {
        public ImageMapping()
        {
            Property(m => m.FileContent).HasColumnType("image");
            Property(m => m.MimeType).IsRequired();
        }
    }
}
