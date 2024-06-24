using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Usda.Fdc.Api.Lib.Converters.EnumTranslators;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters.Single
{
    public class FdcSortOrderConverter : JsonConverter<FdcSortOrder>
    {
        private FdcSortOrderTranslator _translator = new();

        public override FdcSortOrder Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            return _translator.ToEnum(value);
        }

        public override void Write(Utf8JsonWriter writer,
            FdcSortOrder value, JsonSerializerOptions options)
        {

            string? strValue = _translator.FromEnum(value);

            writer.WriteStringValue(strValue);
        }
    }
}
