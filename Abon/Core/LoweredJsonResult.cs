using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Abon.Core
{
    public class LoweredJsonResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data == null) return;

            var s = JsonConvert.SerializeObject(
                Data,
                Formatting.Indented,
                new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()}
                );

            response.Write(s);
        }

        public JsonModel Data { get; set; }

        public Encoding ContentEncoding { get; set; }
    }
}