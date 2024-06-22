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

        internal string FromEnum(FdcSortBy value)
        {
            var castedValue = (FdcSortBy)value;

            switch (castedValue)
            {
                case FdcSortBy.DataType:
                    return "dataType.keyword";
                case FdcSortBy.LowercaseDescription:
                    return "lowercaseDescription.keyword";
                case FdcSortBy.FdcId:
                    return "fdcId";
                case FdcSortBy.PublishedDate:
                    return "publishedDate";
                default:
                    throw new NotSupportedException($"No str value defined for SortBy enum '{castedValue}'");
            }
        }

        internal FdcSortBy ToEnum(string value)
        {
            switch (value)
            {
                case "dataType.keyword":
                    return FdcSortBy.DataType;
                case "lowercaseDescription.keyword":
                    return FdcSortBy.LowercaseDescription;
                case "fdcId":
                    return FdcSortBy.FdcId;
                case "publishedDate":
                    return FdcSortBy.PublishedDate;
                default:
                    throw new NotSupportedException($"No enum value defined for SortBy string '{value}'");
                    throw new NotSupportedException($"No enum value defined for SortBy string '{value}'");
            }
        }
    }
}
