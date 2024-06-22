using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class AbridgedFoodNutrient
    {
        public uint? Number { get; set; }

        public string? Name { get; set; }

        public float? Amount { get; set; }

        public string? UnitName { get; set; }

        public string? DerivationCode { get; set; }

        public string? DerivationDescription { get; set; }
    }
}
