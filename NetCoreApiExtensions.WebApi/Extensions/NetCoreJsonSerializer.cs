using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiExtensions.WebApi.Middleware.Models;

namespace NetCoreApiExtensions.WebApi.Extensions;

/// <summary>
/// NetCoreJsonSerializer for NetCoreApiExtensions.WebApi
/// </summary>
public static class NetCoreJsonSerializer
{
    /// <summary>
    /// Action for configuring the System.Text.Json serializer with the following actions:<br /><br />
    ///
    /// options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;<br />
    /// options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;<br />
    /// options.JsonSerializerOptions.AllowTrailingCommas = true;<br />
    /// options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;<br />
    /// options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());<br />
    /// 
    /// </summary>
    public static Action<JsonOptions> NetCoreJsonConfigurationAction
    {
        get
        {
            return options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = NetCoreJsonSerializerOptions.PropertyNameCaseInsensitive;
                options.JsonSerializerOptions.DefaultIgnoreCondition = NetCoreJsonSerializerOptions.DefaultIgnoreCondition;
                options.JsonSerializerOptions.AllowTrailingCommas = NetCoreJsonSerializerOptions.AllowTrailingCommas;
                options.JsonSerializerOptions.PropertyNamingPolicy = NetCoreJsonSerializerOptions.PropertyNamingPolicy;
                foreach (var jsonConverter in NetCoreJsonSerializerOptions.Converters)
                {
                    options.JsonSerializerOptions.Converters.Add(jsonConverter);
                }
            };
        }
    }


    private static JsonSerializerOptions? _netCoreJsonSerializerOptions;

    /// <summary>
    /// defaults to:
    ///     PropertyNameCaseInsensitive = true;<br />
    ///     DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;<br />
    ///     AllowTrailingCommas = true;<br />
    ///     PropertyNamingPolicy = JsonNamingPolicy.CamelCase;<br />
    ///     Converters.Add(new JsonStringEnumConverter());<br />
    ///<br />
    /// <b>IMPORTANT:</b>When setting this value, set it before any other application action to ensure it is used appropriately by all middleware.
    /// 
    /// </summary>
    public static JsonSerializerOptions NetCoreJsonSerializerOptions
    {
        get
        {
            if (_netCoreJsonSerializerOptions == null)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    AllowTrailingCommas = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                options.Converters.Add(new JsonStringEnumConverter());
                _netCoreJsonSerializerOptions = options;
            }

            return _netCoreJsonSerializerOptions;
        }

        set => _netCoreJsonSerializerOptions = value;
    }

    /// <summary>
    /// Tries to serialize an object using the configuration in <seealso cref="NetCoreJsonSerializerOptions"/>
    /// </summary>
    /// <param name="objectToSerialize"></param>
    /// <returns></returns>
    public static string TrySerializeErrorResult(object objectToSerialize)
    {
        string result;

        try
        {
            result = JsonSerializer.Serialize(objectToSerialize, NetCoreJsonSerializerOptions);
        }
        catch (Exception e)
        {
            result = JsonSerializer.Serialize(new ProcessedErrorDetails<string>
            {
                Message = e.Message,
                Details = "An error occurred serializing the response objectToSerialize"
            }, NetCoreJsonSerializerOptions);
        }

        return result;
    }
}