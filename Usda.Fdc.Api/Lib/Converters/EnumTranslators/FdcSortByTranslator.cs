using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters.EnumTranslators
{
    internal class FdcSortByTranslator
    {
        private static Dictionary<string, FdcSortBy> _strToEnum = new() {
            { "dataType.keyword", FdcSortBy.DataType },
            { "fdcId", FdcSortBy.FdcId },
            { "lowercaseDescription.keyword", FdcSortBy.LowercaseDescription },
            { "publishedDate", FdcSortBy.PublishedDate }
        };

        private static Dictionary<FdcSortBy, string> _enumToStr = _strToEnum
            .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        internal FdcSortBy ToEnum(string value)
        {
            try
            {
                return _strToEnum[value];
            }
            catch
            {
                throw new NotSupportedException($"No enum value defined for SortBy string '{value}'");
            }
        }

        internal string FromEnum(FdcSortBy value)
        {
            try
            {
                return _enumToStr[value];
            }
            catch
            {
                throw new NotSupportedException($"No str value defined for SortBy enum '{value}'");
            }
        }
    }
}
