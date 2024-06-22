using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters
{
    public class FdcSortOrderConverter : JsonConverter<FdcSortOrder>
    {
        public override FdcSortOrder Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            switch (value)
            {
                case "asc":
                    return FdcSortOrder.Asc;
                case "desc":
                    return FdcSortOrder.Desc;
                default:
                    throw new NotSupportedException($"No enum value defined for SortOrder string '{value}'");
            }
        }

        public override void Write(Utf8JsonWriter writer,
            FdcSortOrder value, JsonSerializerOptions options)
        {

            string? strValue = null;

            switch (value)
            {
                case FdcSortOrder.Asc:
                    strValue = "asc";
                    break;
                case FdcSortOrder.Desc:
                    strValue = "desc";
                    break;
                default:
                    throw new NotSupportedException($"No str value defined for SortOrder enum '{value}'");
            }

            writer.WriteStringValue(strValue);
        }
    }
}
