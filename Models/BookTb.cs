using System;
using System.Collections.Generic;

namespace trainingproject.Models
{
    public partial class BookTb
    {
        public BookTb()
        {
            AuthorTbs = new HashSet<AuthorTb>();
        }

        public int BookId { get; set; }
        public string BookReferenceno { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int NoOfPages { get; set; }
        public string NoOfVolume { get; set; } = null!;
        public DateTime? PublishDate { get; set; }

        public virtual ICollection<AuthorTb> AuthorTbs { get; set; }
    }
}
