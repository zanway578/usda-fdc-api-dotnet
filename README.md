# USDA FDC API Wrapper for .NET

## Purpose
The USDA FDC API ([Swaggerhub docs](https://app.swaggerhub.com/apis/fdcnal/food-data_central_api/1.0.1)) is a great resource for finding information on food, including how it's been lab tested and it's nutritional information. There is the option on the swaggerhub page to download client libraries for a variety of languages. While convenient, I found several issues with the C# one:
1. The generated code is messy and calling API endpoints is unintuitive.
2. Lack of enumeration types. Many of the endpoints call for strings that have a fixed number of options (e.g. SortBy, SortOrder, DataType, etc.). As a lover of strong static typing, I didn't like this and wished there was code included to allow for enum types.
3. Lots of pointers floating around in the generated code. I like to avoid pointers in C# unless necessary.
4. If there are any bugs in the generated code, it will be a mess to debug.

Hence, I present an API wrapper that is much easier to use, with the following features:
1. A single API client class `FdcClient` used to contact the API end point.
2. Ability to inject as a singleton instance in any .NET API/Service/Razor/Etc. application.
3. Enumeration types supplied with custom JsonConverters to help with serializing/deserializing JSON.
4. Zero depedencies - written using only System libraries. 

## How to Integrate into Application
1. Clone respository.
2. Either build and add .dll as a reference or add the .csproj file as a project reference in Visual Studio.

## Simple Example
Here's a very basic use of the API client to illustrate how it works:
``` c-sharp
using Usda.Fdc.Api;
using Usda.Fdc.Api.Models;
using Usda.Fdc.Api.Models.Enums;

FdcClient.GlobalApiKey = "{YOUR API KEY}";

// Must inject HTTP client as a dependency
var client = new HttpClient();

// Create objecrt containing criteria for foods we want to search
var listCriteria = new FoodListCriteria()
{
    DataType = new[] { FdcDataType.Foundation },
    SortBy = FdcSortBy.LowercaseDescription,
    SortOrder = FdcSortOrder.Desc,
    PageNumber = 1,
    PageSize = 25
};

var fdcClient = new FdcClient(client);

var foods = await fdcClient.GetFoodList(listCriteria);
```
