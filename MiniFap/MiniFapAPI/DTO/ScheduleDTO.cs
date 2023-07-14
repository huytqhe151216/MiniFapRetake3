namespace MiniFapAPI.DTO
{
    public class ScheduleDTO
    {
        public int ScheduleId { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
        public string Room { get; set; } = null!;
        public int? CourseId { get; set; }
    }
}
