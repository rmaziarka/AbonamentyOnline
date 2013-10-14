using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Abon.Core.Helpers;

namespace Abon.HtmlHelpers
{
    public static class AngularHelper<TModel>
    {
        public static IHtmlString Label<TValue>(Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes = null)
        {
            var member = expression.GetPropertyInformation();
            var name = member.Name.FirstLower();
            var displayText = member.GetPropertyDisplayName();


            string resolvedLabelText = displayText ?? name;

            if (String.IsNullOrEmpty(resolvedLabelText))
            {
                return MvcHtmlString.Empty;
            }

            var tag = new TagBuilder("label");
            tag.Attributes.Add("for", TagBuilder.CreateSanitizedId(name));
            tag.SetInnerText(resolvedLabelText);
            tag.MergeAttributes(htmlAttributes, replaceExisting: true);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static string PropertyName<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            var member = expression.GetPropertyInformation();
            var name = member.Name.FirstLower();
            return name;
        }
    }
}