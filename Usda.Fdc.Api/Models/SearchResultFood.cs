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
    public class SearchResultFood
    {
        public int FdcId { get; set; }

        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public FdcDataType? DataType { get; set; }

        public string Description { get; set; } = null!;

        public object? FoodCode { get; set; }

        public AbridgedFoodNutrient? AbridgedFoodNutrient { get; set; }

        public DateOnly? PublicationDate { get; set; }

        public string? ScientificName { get; set; }

        public string? BrandOwner { get; set; }

        public string? GtinUpc { get; set; }

        public string? Ingredients { get; set; }

        public int? NdbNumber { get; set; }

        public string? AdditionalDescriptions { get; set; }

        public string? AllHighlightFields { get; set; }

        public float? Score { get; set; }
    }
}
