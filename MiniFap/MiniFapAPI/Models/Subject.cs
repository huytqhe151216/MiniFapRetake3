using System;
using System.Collections.Generic;

namespace MiniFapAPI.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }

        public string SubjectId { get; set; } = null!;
        public string SubjectName { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
