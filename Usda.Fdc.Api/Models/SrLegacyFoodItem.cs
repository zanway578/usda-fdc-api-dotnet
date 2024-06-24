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
    public class SrLegacyFoodItem
    {
        public int FdcId { get; set; }

        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public FdcDataType DataType { get; set; }

        public string Description { get; set; } = null!;

        public string? FoodClass { get; set; }

        public string? IsHistoricalReference { get; set; }

        public string? NdbNumber { get; set; }

        public DateOnly? PublicationDate { get; set; }

        public string? ScientificName { get; set; }

        public FoodCategory FoodCategory { get; set; }

        public FoodNutrient[] FoodNutrients { get; set; } = [];

        public NutrientConversionFactors[] NutrientConversionFactors { get; set; } = [];
    }
}
