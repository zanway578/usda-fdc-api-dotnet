using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models
{
    public class SearchResult
    {
        public FoodSearchCriteria FoodSearchCriteria { get; set; } = null!;

        public int TotalHits { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public SearchResultFood[] Foods { get; set; } = [];
    }
}
