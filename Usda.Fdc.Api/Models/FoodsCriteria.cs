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
    public class FoodsCriteria
    {
        public IEnumerable<int> FdcIds { get; set; } = [];

        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public FdcFormat? Format { get; set; } = null!;

        public int[] Nutrients { get; set; } = [];
    }
}
