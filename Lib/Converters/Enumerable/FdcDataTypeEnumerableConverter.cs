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

namespace Usda.Fdc.Api.Lib.Converters.Enumerable
{
    internal class FdcDataTypeEnumerableConverter : JsonConverter<IEnumerable<FdcDataType>>
    {
        FdcDataTypeTranslator _translator = new();

        public override IEnumerable<FdcDataType> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var tokens = new List<FdcDataType>();

            // read start array
            reader.Read();

            try
            {
                while (true)
                {
                    var value = reader.GetString();
                    reader.Read();
                    tokens.Add(_translator.ToEnum(value));
                }
            }
            // read end of array
            catch
            {

            }
            return tokens;
        }

        public override void Write(Utf8JsonWriter writer,
            IEnumerable<FdcDataType> values, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (var value in values)
            {
             
                writer.WriteStringValue(_translator.FromEnum(value));
            }

            writer.WriteEndArray();


        }
    }
}
