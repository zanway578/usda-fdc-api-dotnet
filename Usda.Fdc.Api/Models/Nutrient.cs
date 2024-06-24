using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class Nutrient
    {
        public uint? Id { get; set; }

        public string? Number { get; set; }

        public string? Name { get; set; }

        public uint? Rank { get; set; }

        public string? UnitName { get; set; }
    }
}
