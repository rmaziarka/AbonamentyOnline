using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abon.BusinessLogic.Services.Portal;
using Abon.Dto.Portal.Account;
using Abon.Interfaces.Services.Portal;
using Abon.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;


namespace Abon.Areas.Portal.Controllers
{
    public class FileController : Controller
    {
        public FileController(IFileService fileService)
        {
            _fileService = fileService;

        }

        private Random _random = new Random();

        private IFileService _fileService;

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "id")]
        public ActionResult GetImage(Guid? id)
        {
            if (!id.HasValue)
                return EmptyImage();

            var image = _fileService.GetImage(id.Value);

            if (image != null)
                return File(image.FileContent, image.MimeType);

            return EmptyImage();
        }

        public ActionResult EmptyImage()
        {
            var url = "http://placehold.it/" + _random.Next(350, 450) + "x" + _random.Next(350, 450);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            var httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var stream = httpWebReponse.GetResponseStream();
            return File(stream, "image/jpg");
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Client)]
        public ActionResult GetLoader()
        {
            return File(@"/Content/loader.gif", "image/gif");
        }
    }
}