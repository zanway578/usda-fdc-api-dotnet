using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class InputFoodSurvey
    {
        public int? Id { get; set; }

        public float? Amount { get; set; }

        public string? FoodDescription { get; set; }

        public int? IngredientCode { get; set; }

        public string? IngredientDescription { get; set; }

        public float? IngredientWeight { get; set; }

        public string? PortionCode { get; set; }

        public string? PortionDescription { get; set; }

        public int? SequenceNumber { get; set; }

        public int? SurveyFlag { get; set; }

        public string? Unit { get; set; }

        public InputFood? InputFood { get; set; }

        public RetentionFactor? RetentionFactor { get; set; }
    }
}
