using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters.EnumTranslators
{
    internal class FdcFormatTranslator
    {
        private static readonly Dictionary<string, FdcFormat> _strToEnum = new() {
            { "abridged", FdcFormat.Abridged },
            { "full", FdcFormat.Full }
        };

        private static readonly Dictionary<FdcFormat, string> _enumToStr = _strToEnum
            .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        internal FdcFormat ToEnum(string value)
        {
            try
            {
                return _strToEnum[value];
            }
            catch
            {
                throw new NotSupportedException($"No enum value defined for Format string '{value}'");
            }
        }

        internal string FromEnum(FdcFormat value)
        {
            try
            {
                return _enumToStr[value];
            }
            catch
            {
                throw new NotSupportedException($"No str value defined for Format enum '{value}'");
            }
        }
    }
}
