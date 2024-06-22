using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Usda.Fdc.Api.Lib.Converters.EnumTranslators;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters
{
    internal class FdcDataTypeConverter : JsonConverter<FdcDataType>
    {
        public override FdcDataType Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            return new FdcDataTypeTranslator().ToEnum(value);
        }

        public override void Write(Utf8JsonWriter writer,
            FdcDataType value, JsonSerializerOptions options)
        {
            var strValue = new FdcDataTypeTranslator().FromEnum(value);

            writer.WriteStringValue(strValue);
        }
    }
}
