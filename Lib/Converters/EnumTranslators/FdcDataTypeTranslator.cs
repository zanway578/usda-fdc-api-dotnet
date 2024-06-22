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
        internal FdcDataType ToEnum(string value)
        {
            switch (value)
            {
                case "Branded":
                    return FdcDataType.Branded;
                case "Foundation":
                    return FdcDataType.Foundation;
                case "Survey (FNDDS)":
                    return FdcDataType.Survey;
                case "SR Legacy":
                    return FdcDataType.SrLegacy;
                default:
                    throw new NotSupportedException($"No enum value defined for DataType string '{value}'");
            }
        }

        internal string FromEnum(FdcDataType value)
        {
            string? strValue = null;

            switch (value)
            {
                case FdcDataType.Branded:
                    strValue = "Branded";
                    break;
                case FdcDataType.Foundation:
                    strValue = "Foundation";
                    break;
                case FdcDataType.Survey:
                    strValue = "Survey (FNDDS)";
                    break;
                case FdcDataType.SrLegacy:
                    strValue = "SR Legacy";
                    break;
                default:
                    throw new NotSupportedException($"No str value defined for DataType enum '{value}'");
            }

            return strValue;
        }
    }
}
