using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Usda.Fdc.Api.Lib.Converters;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Models
{
    public class FoodListCriteria
    {
        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public IEnumerable<FdcDataType> DataType { get; set; } = [];

        public int? PageSize  { get; set; }

        public int? PageNumber { get; set; }

        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public FdcSortBy? SortBy { get; set; }

        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public FdcSortOrder? SortOrder { get; set; }
    }
}
