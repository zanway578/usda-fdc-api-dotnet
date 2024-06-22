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
    public class AbridgedFoodItem
    {
        [JsonConverterAttribute(typeof(FdcEnumConverterFactory))]
        public FdcDataType DataType { get; set; }

        /// <summary>
        /// Example: NUT 'N BERRY MIX
        /// </summary>
        public string Description { get; set; } = null!;

        public int FdcId { get; set; }

        public BrandedFoodItem[] FoodNutrients { get; set; } = [];

        public DateOnly? PublicationDate { get; set; }

        /// <summary>
        /// Only applies to Branded foods.
        /// </summary>
        public string? BrandOwner { get; set; }

        /// <summary>
        /// Only applies to Branded foods.
        /// </summary>
        public string? GtinUpc { get; set; }

        /// <summary>
        /// Only applies to Foundation and SRLegacy Foods.
        /// </summary>
        public int? NdbNumber { get; set; }

        /// <summary>
        /// Only applies to Survey Foods
        /// </summary>
        public string? FoodCode { get; set; }
    }
}
