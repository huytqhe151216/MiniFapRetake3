using System;
using System.Collections.Generic;

namespace MiniFapAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            Schedules = new HashSet<Schedule>();
            Users = new HashSet<User>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public int? LecturerId { get; set; }
        public string? SubjectId { get; set; }

        public virtual User? Lecturer { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
