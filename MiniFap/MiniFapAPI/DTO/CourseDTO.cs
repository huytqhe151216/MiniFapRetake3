using MiniFapAPI.Models;

namespace MiniFapAPI.DTO
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public int? LecturerId { get; set; }
        public string? SubjectId { get; set; }
    }
}
