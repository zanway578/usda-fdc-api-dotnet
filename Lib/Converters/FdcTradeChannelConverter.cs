using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters
{
    public class FdcTradeChannelConverter : JsonConverter<FdcTradeChannel?>
    {
        public override FdcTradeChannel? Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            switch (value)
            {
                case null:
                    return null;
                case "CHILD_NUTRITION_FOOD_PROGRAMS":
                    return FdcTradeChannel.ChildNutritionFoodPrograms;
                case "DRUG":
                    return FdcTradeChannel.Drug;
                case "FOOD_SERVICE":
                    return FdcTradeChannel.FoodService;
                case "GROCERY":
                    return FdcTradeChannel.Grocery;
                case "MASS_MERCHANDISING":
                    return FdcTradeChannel.MassMerchandising;
                case "MILITARY":
                    return FdcTradeChannel.Military;
                case "ONLINE":
                    return FdcTradeChannel.Online;
                case "VENDING":
                    return FdcTradeChannel.Vending;
                default:
                    throw new NotSupportedException($"No enum value defined for TradeChannel string '{value}'");
            }
        }

        public override void Write(Utf8JsonWriter writer,
            FdcTradeChannel? value, JsonSerializerOptions options)
        {
            string? strValue;

            switch (value)
            {
                case null:
                    strValue = null;
                    break;
                case FdcTradeChannel.ChildNutritionFoodPrograms:
                    strValue = "CHILD_NUTRITION_FOOD_PROGRAMS";
                    break;
                case FdcTradeChannel.Drug:
                    strValue = "DRUG";
                    break;
                case FdcTradeChannel.FoodService:
                    strValue = "FOOD_SERVICE";
                    break;
                case FdcTradeChannel.Grocery:
                    strValue = "GROCERY";
                    break;
                case FdcTradeChannel.MassMerchandising:
                    strValue = "MASS_MERCHANDISING";
                    break;
                case FdcTradeChannel.Military:
                    strValue = "MILITARY";
                    break;
                case FdcTradeChannel.Online:
                    strValue = "ONLINE";
                    break;
                case FdcTradeChannel.Vending:
                    strValue = "VENDING";
                    break;
                default:
                    throw new NotSupportedException($"No str value defined for TradeChannel enum '{value}'");
            }

            writer.WriteStringValue(strValue);
        }
    }
}
