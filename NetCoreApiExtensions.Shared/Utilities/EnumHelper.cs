using System;
using System.Linq;
using System.Reflection;
using NetCoreApiExtensions.Shared.Enumerations;

namespace NetCoreApiExtensions.Shared.Utilities;

/// <summary>
/// Enum helper class providing methods for interacting with enums
/// </summary>
/// <typeparam name="TEnum">The type of the enum.</typeparam>
public static class EnumHelper<TEnum> where TEnum : struct, Enum
{
    /// <summary>
    /// Gets the default value for the specified enum type if the supplied value cannot be cast to a value for the enum. Default is determined by the
    /// first enum property decorated with the <see cref="DefaultValueAttribute"/>
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>Default Element for the specified enum, or null if no element is decorated with <see cref="DefaultValueAttribute"/></returns>
    public static TEnum? GetValueOrDefault(object value) => GetValueOrDefault<DefaultValueAttribute>(value);


    /// <summary>
    /// Gets the default value for the specified enum type if the supplied value cannot be cast to a value for the enum. Default is determined by the
    /// first enum property decorated with the supplied attribute type.
    /// </summary>
    /// <typeparam name="TAttribute">The type of the attribute used to indicate the default value.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>System.Nullable&lt;TEnum&gt;.</returns>
    public static TEnum? GetValueOrDefault<TAttribute> (object value) where TAttribute : Attribute
    {
        if (value is not string text)
        {
            return null;
        }

        return Enum.TryParse<TEnum>(text, ignoreCase: true, out var result) 
            ? result 
            : GetDefaultValue<TAttribute>();
    }

    /// <summary>
    /// Gets the first enum item decorated with the <see cref="DefaultValueAttribute"/>
    /// </summary>
    /// <returns>System.Nullable&lt;TEnum&gt;.</returns>
    public static TEnum? GetDefaultValue() => GetDefaultValue<DefaultValueAttribute>();

    /// <summary>
    /// Gets the first enum item decorated with the specified attribute
    /// </summary>
    /// <typeparam name="TAttribute">The type of attribute decoration that indicates the default for this enum.</typeparam>
    /// <returns>System.Nullable&lt;TEnum&gt;.</returns>
    public static TEnum? GetDefaultValue<TAttribute>() where TAttribute : Attribute
    {
        var type = typeof(TEnum);
        var defaultMember = type.GetMembers()
            .FirstOrDefault(m => m.GetCustomAttribute(typeof(TAttribute), false) != null);

        if (defaultMember is null)
        {
            return null;
        }

        return Enum.Parse<TEnum>(defaultMember.Name);
    }
}
