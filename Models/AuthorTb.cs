using System;
using System.Collections.Generic;

namespace trainingproject.Models
{
    public partial class AuthorTb
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public int ExperienceInYears { get; set; }
        public int? BookId { get; set; }

        public virtual BookTb? Book { get; set; }
    }
}
