using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class NutrientAquisitionDetails
    {
        public int? SampleUnitId { get; set; }

        public string? PurchaseDate { get; set; }

        public string? StoreCity { get; set; }

        public string? StoreState { get; set; }
    }
}
