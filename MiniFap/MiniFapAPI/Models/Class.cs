using System;
using System.Collections.Generic;

namespace MiniFapAPI.Models
{
    public partial class Class
    {
        public Class()
        {
            Users = new HashSet<User>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
