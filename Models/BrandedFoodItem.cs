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
    public class BrandedFoodItem
    {
        public int FdcId { get; set; }

        public DateOnly? AvailableDate { get; set; }

        public string? BrandOwner { get; set; }

        public string? DateSource { get; set; }

        public string DateType { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? FoodClass { get; set; }

        public string? GtinUpc { get; set; }

        public string? HouseHoldServingFullText { get; set; }

        public string? Ingredients { get; set; }

        public DateOnly? ModifiedDate { get; set; }

        public DateOnly? PublicationDate { get; set; }

        public float? ServingSize { get; set; }

        public string? ServingSizeUnit { get; set; }

        public string? PreparationStateCode { get; set; }

        public string? BrandedFoodCategory { get; set; }

        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public IEnumerable<FdcTradeChannel> TradeChannel { get; set; } = [];

        public int? GpcClasCode { get; set; }

        public FoodNutrient[] FoodNutrients { get; set; } = [];

        public FoodUpdateLog[] FoodUpdateLog { get; set; } = [];

        public Dictionary<string, string> LabelNutrients = [];
    }
}
