using Microsoft.OpenApi.Extensions;
using System.ComponentModel;

namespace PrashantEle.API.PrashantEle.Infrastructure.Constants
{
    public static class EnumHelper
    {
        public static T GetAttributeOfType<T>(this Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
        public static string GetEnumDescription(this Enum enumVariable)
        {
            if (enumVariable == null) return string.Empty;

            var descAttr = enumVariable.GetAttributeOfType<DescriptionAttribute>();

            return descAttr != null ? descAttr.Description : enumVariable.ToString();
        }
    }
}
