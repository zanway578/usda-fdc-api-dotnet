using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters.EnumTranslators
{
    internal class FdcSortOrderTranslator
    {
        private static readonly Dictionary<string, FdcSortOrder> _strToEnum = new() {
            { "asc", FdcSortOrder.Asc },
            { "desc", FdcSortOrder.Desc }
        };

        private static readonly Dictionary<FdcSortOrder, string> _enumToStr = _strToEnum
            .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        internal FdcSortOrder ToEnum(string value)
        {
            try
            {
                return _strToEnum[value];
            }
            catch
            {
                throw new NotSupportedException($"No enum value defined for SortOrder string '{value}'");
            }
        }

        internal string FromEnum(FdcSortOrder value)
        {
            try
            {
                return _enumToStr[value];
            }
            catch
            {
                throw new NotSupportedException($"No str value defined for SortOrder enum '{value}'");
            }
        }
    }
}
