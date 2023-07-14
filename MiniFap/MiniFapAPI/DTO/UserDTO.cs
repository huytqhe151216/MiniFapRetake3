namespace MiniFapAPI.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int? RoleId { get; set; }
        public string? StudentId { get; set; }
        public int? ClassId { get; set; }
    }
}
