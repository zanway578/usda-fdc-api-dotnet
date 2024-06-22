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
    public class FoodUpdateLog
    {
        public int? FdcId { get; set; }

        public DateOnly? AvailableDate { get; set; }

        public string? BrandOwner { get; set; }

        public string? DataSource { get; set; }

        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public FdcDataType? DataType { get; set; }

        public string? Description { get; set; }

        public string? FoodClass { get; set; }

        public string? GtinUpc { get; set; }

        public string? HouseholdServingFullText { get; set; }

        public string? Ingredients { get; set; }

        public DateOnly? ModifiedDate { get; set; }

        public DateOnly? PublicationDate { get; set; }

        public float? ServingSize { get; set; }

        public string? ServingSizeUnit { get; set; }

        public string? BrandedFoodCategory { get; set; }

        public string? Changes { get; set; }

        public FoodAttribute[] FoodAttributes { get; set; } = [];
    }
}
