﻿using System;
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
        [JsonRequired]
        public FdcDataType DataType { get; set; }

        /// <summary>
        /// Example: NUT 'N BERRY MIX
        /// </summary>
        [JsonRequired]
        public string Description { get; set; } = null!;

        [JsonRequired]
        public int FdcId { get; set; }

        public IEnumerable<AbridgedFoodNutrient> FoodNutrients { get; set; } = [];

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
        public string? NdbNumber { get; set; }

        /// <summary>
        /// Only applies to Survey Foods
        /// </summary>
        public object? FoodCode { get; set; }
    }
}
