using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters.EnumTranslators
{
    internal class FdcDataTypeTranslator
    {
        private static readonly Dictionary<string, FdcDataType> _strToEnum = new() {
            { "Branded", FdcDataType.Branded },
            { "Foundation", FdcDataType.Foundation },
            { "Experimental", FdcDataType.Experimental },
            { "SR Legacy", FdcDataType.SrLegacy },
            { "Survey (FNDDS)", FdcDataType.Survey }
        };

        private static readonly Dictionary<FdcDataType, string> _enumToStr = _strToEnum
            .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        internal FdcDataType ToEnum(string value)
        {
            try
            {
                return _strToEnum[value];
            }
            catch
            {
                throw new NotSupportedException($"No enum value defined for DataType string '{value}'");
            }
        }

        internal string FromEnum(FdcDataType value)
        {
            try
            {
                return _enumToStr[value];
            }
            catch
            {
                throw new NotSupportedException($"No str value defined for DataType enum '{value}'");
            }
        }
    }
}
