using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Usda.Fdc.Api.Lib.Converters.EnumTranslators;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters
{
    internal class FdcEnumerableConverter : JsonConverter<IEnumerable<FdcDataType>>
    {

        public override IEnumerable<FdcDataType> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            var value = reader.GetString();

            return new FdcDataType[0];
        }

        public override void Write(Utf8JsonWriter writer,
            IEnumerable<FdcDataType> values, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (var value in values)
            {
                var enumerator = new FdcDataTypeTranslator();

                writer.WriteStringValue(enumerator.FromEnum(value));
            }

            writer.WriteEndArray();

            
        }
    }
}
