using System;
using System.Collections.Generic;

namespace MiniFapAPI.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
        public string Room { get; set; } = null!;
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
    }
}
