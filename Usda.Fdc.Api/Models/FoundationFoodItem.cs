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
    public class FoundationFoodItem
    {
        public int FdcId { get; set; }

        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public FdcDataType DataType { get; set; }

        public string Description { get; set; } = null!;
       
        public string? FoodClass { get; set; }

        public string? FootNote { get; set; }

        public bool? IsHistoricalReference { get; set; }

        public int NdbNumber { get; set; }

        public DateOnly? PublicationDate { get; set; }

        public string? ScientificName { get; set; }

        public FoodCategory? FoodCategory { get; set; }

        public FoodComponent[] FoodComponents { get; set; } = [];

        public FoodNutrient[] FoodNutrients { get; set; } = [];

        public FoodPortion[] FoodPortions { get; set; } = [];

        public InputFoodFoundation[] InputFoods { get; set; } = [];

        public NutrientConversionFactors[] NutrientConversionFactors { get; set; } = [];
    }
}
