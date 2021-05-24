using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NetCoreApiExtensions.Shared.Extensions
{
    public static class EnumExtensions
    {
        /// <returns>Returns the entire enum list as ListItems, using the description attribute or [value]:G as the value, and the enum value as the key.</returns>
        public static List<ListItem<T, string>> GetEnumList<T>(this T enumValue) where T : struct, Enum
        {
            return GetEnumList<T, DescriptionAttribute>(enumValue, descriptionAttribute => descriptionAttribute.Description);
        }

        /// <returns>Returns the entire enum list as ListItems, using the attribute to string method  or [value]:G as the value, and the enum value as the key.</returns>
        public static List<ListItem<T, string>> GetEnumList<T, TA>(this T enumValue, Func<TA, string> descriptionMethod) where T : struct, Enum where TA : Attribute
        {
            var results = new List<ListItem<T, string>>();

            try
            {
                if (enumValue is Enum listType)
                {
                    var type = typeof(T);
                    var values = Enum.GetNames(type);
                    foreach (var val in values)
                    {
                        if (!Enum.TryParse(val, true, out T parsedValue))
                        {
                            continue;
                        }

                        var stringValue = $"{parsedValue:G}";
                        var memInfo = type.GetMember(stringValue);
                        if (memInfo[0]
                            .GetCustomAttributes(typeof(TA), false)
                            .FirstOrDefault() is TA attribute)
                        {
                            var valueString = descriptionMethod.Invoke(attribute);
                            results.Add(new ListItem<T, string> { Key = parsedValue, Value = valueString });
                        }
                        else
                        {
                            results.Add(new ListItem<T, string> { Key = parsedValue, Value = stringValue });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return results;
        }
    }
}