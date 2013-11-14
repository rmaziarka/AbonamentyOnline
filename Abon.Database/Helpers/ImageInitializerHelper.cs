using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Abon.Database.Helpers
{
    public class ImageInitializerHelper
    {
        public ImageInitializerHelper(ImageTypes imageType)
        {
            switch (imageType)
            {
                case ImageTypes.Category:
                    Directories = DirectoriesToCategoryImages;
                    break;

                case ImageTypes.Offer:
                    Directories = DirectoriesToOfferImages;
                    break;

                case ImageTypes.Company:
                    Directories = DirectoriesToCompanyImages;
                    break;
            }
        }
        public readonly string[] DirectoriesToCategoryImages = new[] { "img", "initializer", "categories" };

        public readonly string[] DirectoriesToOfferImages = new[] { "img", "initializer", "offers" };

        public readonly string[] DirectoriesToCompanyImages = new[] { "img", "initializer", "companies" };

        public string[] Directories { get; set; }

        public byte[] GetImageData(string fileName)
        {
            var path = GetPathToImage(fileName);
            return File.ReadAllBytes(path);
        }

        public string GetImageMimeType(string fileName)
        {
            var path = GetPathToImage(fileName);
            var bitmap = Bitmap.FromFile(path);
            return GetImageMimeType(bitmap);
        }

        public string GetImageMimeType(Image bitmap)
        {
            string sReturn = string.Empty;


            if (bitmap.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                sReturn = "bmp";
            else if (bitmap.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Emf.Guid)
                sReturn = "emf";
            else if (bitmap.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Exif.Guid)
                sReturn = "exif";
            else if (bitmap.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                sReturn = "gif";
            else if (bitmap.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Icon.Guid)
                sReturn = "icon";
            else if (bitmap.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                sReturn = "jpeg";
            else if (bitmap.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.MemoryBmp.Guid)
                sReturn = "membmp";
            else if (bitmap.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                sReturn = "png";
            else if (bitmap.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Tiff.Guid)
                sReturn = "tiff";
            else if (bitmap.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Wmf.Guid)
                sReturn = "wmf";
            else
                sReturn = "unknown";
            return sReturn;
        }

        public string GetPathToImage(string filename)
        {
            var serverPath = HostingEnvironment.MapPath("~");

            var paths = new List<string>();
            paths.Add(serverPath);
            paths.AddRange(Directories);
            paths.Add(filename);

            var filePath = Path.Combine(paths.ToArray());
            return filePath;
        }
    }

    public enum ImageTypes
    {
        Category, Offer,
        Company
    }
}
