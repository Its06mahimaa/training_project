using System;
using System.Collections.Generic;

namespace trainingproject.Models
{
    public partial class CategoryTb
    {
        public CategoryTb()
        {
            SubcategoryTbs = new HashSet<SubcategoryTb>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<SubcategoryTb> SubcategoryTbs { get; set; }
    }
}
