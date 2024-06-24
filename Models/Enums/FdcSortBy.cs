using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usda.Fdc.Api.Models.Enums
{
    public enum FdcSortBy
    {
        /// <summary>
        /// Dataset food comes from (see enum type "FdcDataType" for available datasets)
        /// </summary>
        DataType,
        /// <summary>
        /// Description of food (e.g. "Cheddar cheese", "Milk", etc.)
        /// </summary>
        LowercaseDescription,
        /// <summary>
        /// Unique ID of food item
        /// </summary>
        FdcId,
        /// <summary>
        /// When food was published to dataset
        /// </summary>
        PublishedDate
    }
}
