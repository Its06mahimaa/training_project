using System;
using System.Collections.Generic;

namespace trainingproject.Models
{
    public partial class SubcategoryTb
    {
        public int SubCatId { get; set; }
        public string SubCatName { get; set; } = null!;
        public int? CategoryId { get; set; }

        public virtual CategoryTb? Category { get; set; }
    }
}
