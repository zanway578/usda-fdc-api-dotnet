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
        internal string FromEnum(FdcSortOrder value)
        {
            switch (value)
            {
                case FdcSortOrder.Asc:
                    return "asc";
                case FdcSortOrder.Desc:
                    return "desc";
                default:
                    throw new NotSupportedException($"No str value defined for SortOrder enum '{value}'");
            }
        }

        internal FdcSortOrder ToEnum(string value)
        {
            switch (value)
            {
                case "asc":
                    return FdcSortOrder.Asc;
                case "desc":
                    return FdcSortOrder.Desc;
                default:
                    throw new NotSupportedException($"No enum value defined for SortOrder string '{value}'");
            }
        }
    }
}
