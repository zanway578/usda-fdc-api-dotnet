using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class FoodPortion
    {
        public int? Id { get; set; }

        public float? Amount { get; set; }

        public int? DataPoints { get; set; }

        public float? GramWeight { get; set; }

        public int? MinYearAquired { get; set; }

        public string? Modifier { get; set; }

        public string? PortionDescription { get; set; }

        public int? Sequenceumber { get; set; }

        public MeasureUnit MeasureUnit { get; set; }
    }
}
