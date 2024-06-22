using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class FoodAttribute
    {
        public int? Id { get; set; }

        public int? SequenceNumber { get; set; }

        public string? Value { get; set; }

        public FoodAttributeType FoodAttributeType { get; set; }
    }
}
