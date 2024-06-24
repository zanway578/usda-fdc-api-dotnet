using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class NutrientAnalysisDetails
    {
        public int? SubSampleId { get; set; }

        public float? Amount { get; set; }

        public int? NutrientId { get; set; }

        public string? LabMethodDescription { get; set; }

        public string? LabMethodOriginalDescription { get; set; }

        public string? LabMethodLink { get; set; }

        public string? LabMethodTechnique { get; set; }

        public NutrientAquisitionDetails[] NutrientAquisitionDetails { get; set; } = [];
    }
}
