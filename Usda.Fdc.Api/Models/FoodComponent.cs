using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class FoodComponent
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? DataPoints { get; set; }

        public float? GramWeight { get; set; }

        public bool? isRefuse { get; set; }

        public int? MinYearAquired { get; set; }

        public float? PercentWeight { get; set; }
    }
}
