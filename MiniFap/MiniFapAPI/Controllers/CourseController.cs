using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniFapAPI.DTO;
using MiniFapAPI.Models;

namespace MiniFapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly MiniFap5Context _context;
        private readonly IMapper _mapper;

        public CourseController(MiniFap5Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("CreateCourse")]
        public IActionResult CreateCourse(CourseDTO courseDTO)
        {
            if (courseDTO==null)
            {
                return BadRequest();
            }
            try
            {
                _context.Courses.Add(_mapper.Map<Course>(courseDTO));
                _context.SaveChanges();
                return Ok("Add successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Add fail:" + ex.Message);
                
            }
            
        }
        [HttpPost("AddClassToCourse")]
        public IActionResult AddClassToCourse(int classId, int courseId)
        {
            try
            {
                Course c = _context.Courses.FirstOrDefault(x => x.CourseId == courseId);
                List<User> users = _context.Users.Where(x => x.ClassId == classId).ToList();
                foreach (var item in users)
                {
                    item.Courses.Add(c);
                    c.Users.Add(item);
                }
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Student has been in this course");
                throw;
            }
            
        }
        [HttpPost("AddStudentToCourse")]
        public IActionResult AddStudentToCourse(int userId, int courseId)
        {
            try
            {
                Course c = _context.Courses.FirstOrDefault(x => x.CourseId == courseId);
                User u = _context.Users.FirstOrDefault(x => x.UserId == userId);
                
                u.Courses.Add(c);
                c.Users.Add(u);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Student has been in this course");
                throw;
            }

        }

    }
}
