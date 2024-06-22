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
    public class SurveyFoodItem
    {
        public int FdcId { get; set; }

        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public FdcDataType? DataType { get; set; }

        public string Description { get; set; } = null!;

        public DateOnly? EndDate { get; set; }

        public string? FoodClass { get; set; }

        public string? FoodCode { get; set; }

        public DateOnly? PublicationDate { get; set; }

        public DateOnly? StartDate { get; set; }

        public FoodAttribute[] FoodAttributes { get; set; } = [];

        public FoodPortion[] FoodPortions { get; set; } = [];

        public InputFoodSurvey[] InputFoods { get; set; } = [];

        public WweiaFoodCategory? WweiaFoodCategory { get; set; }
    }
}
