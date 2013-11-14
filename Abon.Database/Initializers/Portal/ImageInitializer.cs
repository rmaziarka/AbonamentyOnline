using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model.Portal;
using Abon.Database.Model.Portal.Enums;
using Abon.Database.Helpers;

namespace Abon.Database.Initializers.Portal
{
    public class ImageInitializer : IDbInitializer<Image>
    {
        
        public List<Image> Initialize()
        {


            var list = new List<Image>();

            list.AddRange(GetCategoryImages());
            list.AddRange(GetCompanyImages());

            return list;

        }

        public IEnumerable<Image> GetCompanyImages()
        {
            var categoryImageHelper = new ImageInitializerHelper(ImageTypes.Company);

            return new List<Image>()
                {
                    new Image
                        {
                            Id = Guid.Parse("eacac2c8-0f68-49dd-a9e7-4ac50f894966"),
                            MimeType = categoryImageHelper.GetImageMimeType("insert-logo.png"),
                            FileContent = categoryImageHelper.GetImageData("insert-logo.png")
                        }

                };
        }

        public IEnumerable<Image> GetCategoryImages()
        {
            var categoryImageHelper = new ImageInitializerHelper(ImageTypes.Category);

            return new List<Image>()
                {
                    new Image
                        {
                            Id = Guid.Parse("02313c5a-cc01-4ce5-96a1-0609196c3515"),
                            MimeType = categoryImageHelper.GetImageMimeType("icon-it.png"),
                            FileContent = categoryImageHelper.GetImageData("icon-it.png")
                        },
                    new Image
                        {
                            Id = Guid.Parse("2269152f-9a6b-4023-8009-b57038aefd57"),
                            MimeType = categoryImageHelper.GetImageMimeType("icon-subsc.png"),
                            FileContent = categoryImageHelper.GetImageData("icon-subsc.png")
                        },

                };

        }
    }
}
