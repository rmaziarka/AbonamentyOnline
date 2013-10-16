using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abon.Core
{
    public class AbonController:Controller
    {

        public LoweredJsonResult LoweredJson(JsonModel model)
        {
            return new LoweredJsonResult(){Data = model};
        }

        public LoweredJsonResult LoweredJson()
        {
            return new LoweredJsonResult();
        }

        public LoweredJsonResult LoweredJson(object data)
        {
            return new LoweredJsonResult(){Data = new JsonModel(){Data = data}};
        }
    }
}