using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class AbridgedFoodNutrient
    {
        public string Number { get; set; } = null!;

        public string Name { get; set; } = null!;

        public float Amount { get; set; }

        public string UnitName { get; set; } = null!;

        public string? DerivationCode { get; set; }

        public string? DerivationDescription { get; set; }
    }
}
