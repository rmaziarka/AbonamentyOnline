using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Abon.HtmlHelpers
{
    public static class JsonParseHtmlHelper
    {
            public static IHtmlString ToJson(this HtmlHelper htmlHelper, object obj)
            {
                var s = htmlHelper.Raw(JsonConvert.SerializeObject(obj));

                return s;
            }

            public static IHtmlString ToCamelCaseJson(this HtmlHelper htmlHelper, object obj)
            {
                var s = JsonConvert.SerializeObject(obj,
                                Newtonsoft.Json.Formatting.None,
                                new JsonSerializerSettings()
                                {
                                    NullValueHandling = NullValueHandling.Ignore,
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                                });
                var htmlString = htmlHelper.Raw(s);

                return htmlString;
            }
        }
    
}