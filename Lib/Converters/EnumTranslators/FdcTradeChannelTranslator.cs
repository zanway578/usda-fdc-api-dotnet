using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usda.Fdc.Api.Models.Enums;

namespace Usda.Fdc.Api.Lib.Converters.EnumTranslators
{
    internal class FdcTradeChannelTranslator
    {
        internal string FromEnum(FdcTradeChannel value)
        {
            switch (value)
            {
                case FdcTradeChannel.ChildNutritionFoodPrograms:
                    return"CHILD_NUTRITION_FOOD_PROGRAMS";
                case FdcTradeChannel.Drug:
                    return "DRUG";
                case FdcTradeChannel.FoodService:
                    return "FOOD_SERVICE";
                case FdcTradeChannel.Grocery:
                    return "GROCERY";
                case FdcTradeChannel.MassMerchandising:
                    return "MASS_MERCHANDISING";
                case FdcTradeChannel.Military:
                    return "MILITARY";
                case FdcTradeChannel.Online:
                    return "ONLINE";
                case FdcTradeChannel.Vending:
                    return "VENDING";
                default:
                    throw new NotSupportedException($"No str value defined for TradeChannel enum '{value}'");
            }
        }

        internal FdcTradeChannel ToEnum(string value)
        {
            switch (value)
            {
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
    }
}
