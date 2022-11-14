# What's Inside

A collection of classes that can help create good domain, request, and response patterns, along with API error classes to make intentional status code errors easier to surface. 


# Change Log

## 1.4.0.0
Added Net 7 Support

## 1.3.4.0
Added parameterless constructors for json serializer support to `DataResponse` and `ErrorResponse` classes to better support their use in unit testing.

## 1.3.3.0

Brought over some response generics from `NetCoreApiExtensions.WebApi` since it has a dependency here, and those generics make more sense in this context.