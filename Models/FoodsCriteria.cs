using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class FoodsCriteria
    {
        public int[] FdcIds { get; set; } = [];

        public string Format { get; set; } = null!;

        public int[] Nutrients { get; set; } = [];
    }
}
