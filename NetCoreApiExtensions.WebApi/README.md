# NetCoreApiExtensions.WebApi
---
This package provides an opinionated way to create versioned APIs by convention. There are 2 main parts for implementing this pattern. First, making the application look for the convetion and second, connecting controllers to the convention.

There are other features and usages that are not fully documented here, but this is a fast-track primer to setting things up.

## BuildNetCoreApi (Extension)
| Parameter | Type | Default | Usage | 
| ----------- | ----------- | ---------- | ---------- |
| `apiTitle` | `string` | | Tells SwaggerUI what title to display for your API |
| `groupNameFormat` | `string` | `"'v'VVV"` | Tells the application how to format your API versions. Supports [ApiVersionFormatProvider](https://github.com/dotnet/aspnet-api-versioning/wiki/Version-Format) formats. |

## VersionedApiControllerAttribute

Provides the basic versioning for an API controller. Inherits `ApiControllerAttribute`
and supplies a versioned route template.

| Parameter | Type | Default | Usage | 
| ----------- | ----------- | ---------- | ---------- |
| `rootResourceSegments` | `params string[]` | | If supplied, parameters are split and added to the end of the template, joined by `/` |

Route Template without `rootResourceSegments`:

```
$"api/v{{version:apiVersion}}/[Controller]"
```

Route Template with `rootResourceSegments`:

```
$"api/v{{version:apiVersion}}/[Controller]/{{string.Join('/', pathSegments)}}
```

## Core

There are many extensions methods provided by this package that can be used to tailor the experience, but the fastest (and most consistent) way to get started is by using the top-level extension that acts as a `WebApplication` factory and replaces the standard `Build()` call.

The API project stubs this:
``` C#
var app = builder.Build();
```

you should replace that line with:
``` C#
var app = builder.BuildNetCoreApi("<your API Title>");
```

Substitute in the name that you want displayed in SwaggerUI as the parameter to the method. Since this replaces the `builder.Build()` call and does that internally, this should be the *LAST* thing you do before you continuing to configure the app.

## Exception Middleware
This middleware is designed to sanitize errors using classes from the `NetCoreApiExtensions.Shared` package to respond with meaningful codes when `StatusCodeExceptions` are thrown. It has specific handling for `FluentValidation.ValidationException` and `DataAnnotation.ValidationException` as well that result in `400` responses. Everything else is returned as a `500`. `ILogger` is supported in the following ways:

### NetCoreApiExtension.Shared Exceptions:
* Warning logged

### Validation Exceptions: 
* Not logged
  
### Unhandled exception Cases:
* Error Logged
  

Adding the exception handling Middleware is simple. Once you have your `WebApplication` instance, add the line:

``` C#
app.UseMiddleware<NetCoreApiExtensionsExceptionHandlingMiddleware>();
```



## What's in it for you?
### Less Configuration
Using the **Asp.Net Core Web Api** for .Net 6 creates a `program.cs` that looks like this:
``` C#
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```
With this package, that can be reduced to:
``` C# 
using NetCoreApiExtensions.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.BuildNetCoreApi("Demo API");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```

### Convention-based API Versioning
This package brings in some `MVC` dependencies that allow your endpoints to be versioned by convention. This does require that your API be organized in a specific way.

#### Folder Struture
```
Api.Project
    - v1_0
        - Controllers
            - WeatherForcastController.cs
    - v2_2
        - Controllers
            - WeatherForcastController.cs
    - v3_0-beta
        - Controllers
            - WeatherForcastController.cs
```
This folder structure will create 3 versions of the `WeatherForcastController` along with 3 distinct versions (selectable from the dropdown) in SwaggerUI:

`v1`, `v2.2`, and `v3-beta` 

# Change Log
---
## 2.1.0
* Added formal middleware to handle Exceptions
  
## 2.0.2
Added
* Extensions to configure Web APIs
* Documentation on usage