using Abon.Database.Model.Portal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abon.Core
{
    public class AbonController:Controller
    {
        public OfferType OfferType
        {
            get{
                return (OfferType)Session["OfferType"];
            }
            set
            {
                Session["OfferType"] = value;
                SetOfferTypeToResponse(value);
            }

        }

        protected LoweredJsonResult LoweredJson(JsonModel model)
        {
            return new LoweredJsonResult(){Data = model};
        }

        protected LoweredJsonResult LoweredJson()
        {
            return new LoweredJsonResult();
        }

        protected LoweredJsonResult LoweredJson(object data)
        {
            return new LoweredJsonResult(){Data = new JsonModel(){Data = data}};
        }

        protected void SetOfferTypeToResponse(OfferType offerType)
        {
            HttpCookie cookie = new HttpCookie("offerType");

            cookie.Value = offerType.ToString();

            cookie.Expires = DateTime.Now.AddYears(1);

            Response.Cookies.Add(cookie);
        }

        protected OfferType GetOfferType()
        {
            var cookie = Request.Cookies["offerType"];

            if (cookie == null)
                return OfferType.Individual;

            OfferType offerType; 
            Enum.TryParse<OfferType>(cookie.Value, out offerType);

            return offerType;
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(Session["OfferType"] == null)
                Session["OfferType"] = GetOfferType();

            base.OnActionExecuting(filterContext);
        }
        protected override  void OnActionExecuted(ActionExecutedContext filterContext)
        {

            ViewBag.OfferTypeClass = OfferType == OfferType.Individual ? "individual" : "business";
            ViewBag.OfferTypePath = OfferType == OfferType.Individual ? "UserOffers" : "BusinessOffers";
            base.OnActionExecuted(filterContext);
        }
    }
}