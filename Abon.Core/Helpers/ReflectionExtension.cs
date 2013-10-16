using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Abon.Core.Helpers
{
    public static class ReflectionExtension
    {
        public static T GetAttribute<T>(this MemberInfo member, bool isRequired)
            where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

            if (attribute == null && isRequired)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "The {0} attribute must be defined on member {1}",
                        typeof(T).Name,
                        member.Name));
            }

            return (T)attribute;
        }


        public static string GetPropertyDisplayName(this MemberInfo memberInfo)
        {
            var attr = memberInfo.GetAttribute<DisplayNameAttribute>(false);
            if (attr == null)
            {
                return memberInfo.Name;
            }

            return attr.DisplayName;
        }

        public static string GetPropertyDisplayName<TModel, TProperty>(this Expression<Func<TModel, TProperty>> propertyExpression)
        {
            var memberInfo = GetPropertyInformation(propertyExpression);
            if (memberInfo == null)
            {
                throw new ArgumentException(
                    "No property reference expression was found.",
                    "propertyExpression");
            }

            var attr = memberInfo.GetAttribute<DisplayNameAttribute>(false);
            if (attr == null)
            {
                return memberInfo.Name;
            }

            return attr.DisplayName;
        }

        public static MemberInfo GetPropertyInformation<TModel, TProperty>(this Expression<Func<TModel, TProperty>> propertyExpression)
        {
            var memberExpr = propertyExpression.Body as MemberExpression;

            return memberExpr != null ? memberExpr.Member : null;
        }
    }
}