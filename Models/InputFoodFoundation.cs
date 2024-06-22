using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class InputFoodFoundation
    {
        public int? Id { get; set; }

        public string? FoodDescription { get; set; }

        public SampleFoodItem? InputFood { get; set; } = null;
    }
}
