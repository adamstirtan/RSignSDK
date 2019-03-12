using System;
using System.ComponentModel;

namespace RSignSDK.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum @enum)
        {
            var fieldInfo = @enum.GetType().GetField(@enum.ToString());

            if (fieldInfo == null)
            {
                return @enum.ToString();
            }

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : @enum.ToString();
        }
    }
}