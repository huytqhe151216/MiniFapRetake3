using System;
using System.Collections.Generic;

namespace MiniFapAPI.Models
{
    public partial class User
    {
        public User()
        {
            Courses = new HashSet<Course>();
            CoursesNavigation = new HashSet<Course>();
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int? RoleId { get; set; }
        public string? StudentId { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Course> CoursesNavigation { get; set; }
    }
}
