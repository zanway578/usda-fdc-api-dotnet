using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters
{
    internal class FdcSortByConverter : JsonConverter<FdcSortBy>
    {
        public override FdcSortBy Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            switch (value)
            {
                case "dataType.keyword":
                    return FdcSortBy.DataType;
                case "lowercaseDescription.keyword":
                    return FdcSortBy.LowercaseDescription;
                case "fdcId":
                    return FdcSortBy.FdcId;
                case "publishedDate":
                    return FdcSortBy.PublishedDate;
                default:
                    throw new NotSupportedException($"No enum value defined for SortBy string '{value}'");
            }
        }

        public override void Write(Utf8JsonWriter writer,
            FdcSortBy value, JsonSerializerOptions options)
        {
            string? strValue;

            switch(value)
            {
                case FdcSortBy.DataType:
                    strValue = "dataType.keyword";
                    break;
                case FdcSortBy.LowercaseDescription:
                    strValue = "lowercaseDescription.keyword";
                    break;
                case FdcSortBy.FdcId:
                    strValue = "fdcId";
                    break;
                case FdcSortBy.PublishedDate:
                    strValue = "publishedDate";
                    break;
                default:
                    throw new NotSupportedException($"No str value defined for SortBy enum '{value}'");
            }

            writer.WriteStringValue(strValue);
        }
    }
}
