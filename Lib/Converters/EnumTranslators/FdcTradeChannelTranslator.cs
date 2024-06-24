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
        private static readonly Dictionary<string, FdcTradeChannel> _strToEnum = new()
        {
            { "CHILD_NUTRITION_FOOD_PROGRAMS", FdcTradeChannel.ChildNutritionFoodPrograms },
            { "DRUG", FdcTradeChannel.Drug },
            { "FOOD_SERVICE", FdcTradeChannel.FoodService },
            { "GROCERY", FdcTradeChannel.Grocery },
            { "MASS_MERCHANDISING", FdcTradeChannel.MassMerchandising },
            { "MILITARY", FdcTradeChannel.Military },
            { "ONLINE", FdcTradeChannel.Online },
            { "VENDING", FdcTradeChannel.Vending }
        };

        private static readonly Dictionary<FdcTradeChannel, string> _enumToStr = _strToEnum
            .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        internal string FromEnum(FdcTradeChannel value)
        {
            try
            {
                return _enumToStr[value];
            }
            catch
            {
                throw new NotSupportedException($"No str value defined for TradeChannel enum '{value}'");
            }
        }

        internal FdcTradeChannel ToEnum(string value)
        {
            try
            {
                return _strToEnum[value];
            }
            catch
            {
                throw new NotSupportedException($"No enum value defined for TradeChannel string '{value}'");
            }
        }
    }
}
