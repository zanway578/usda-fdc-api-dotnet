using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters
{
    internal class FdcEnumConverterFactory : JsonConverterFactory
    {
        private bool CanConvertToEnumerableInterface(Type typeToConvert)
        {
            var enumerableTypes = new Type[] { 
                typeof(FdcDataType), 
                typeof(FdcSortBy), 
                typeof(FdcSortOrder), 
                typeof(FdcTradeChannel) };

            var isEnumerable = typeof(IEnumerable).IsAssignableFrom(typeToConvert);

            if (!isEnumerable)
            {
                return false;
            }
            else
            {
                try
                {
                    return enumerableTypes.Contains(typeToConvert.GetGenericArguments()[0]);
                }
                catch
                {
                    return false;
                }
            }
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return 
                typeToConvert == typeof(FdcSortBy) ||
                typeToConvert == typeof(FdcSortOrder) ||
                typeToConvert == typeof(FdcDataType) ||
                typeToConvert == typeof(FdcTradeChannel) ||
                CanConvertToEnumerableInterface(typeToConvert);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert == typeof(FdcDataType))
            {
                return new FdcDataTypeConverter();
            }
            else if (typeToConvert == typeof(FdcSortBy))
            {
                return new FdcSortByConverter();
            }
            else if (typeToConvert == typeof(FdcSortOrder))
            {
                return new FdcSortOrderConverter();
            }
            else if (typeToConvert == typeof(FdcTradeChannel))
            {
                return new FdcTradeChannelConverter();
            }
            else if (CanConvertToEnumerableInterface(typeToConvert))
            {
                return new FdcEnumerableConverter();
            }
            else
            {
                throw new NotSupportedException("Type passed to converter factory that cannot be converted.");
            }
        }
    }
}
