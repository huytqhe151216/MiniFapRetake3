using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniFapAPI.DTO;
using MiniFapAPI.Models;
using System.Data;

namespace MiniFapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly MiniFap5Context _context;
        private readonly IMapper _mapper;

        public ScheduleController(MiniFap5Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetScheduleOfStudent")]
        public IActionResult GetScheduleOfStudent(int userId,DateTime dateFrom, DateTime dateEnd)
        {
            try
            {
                using (_context)
                {
                    var query = @"select s.*,c.CourseName from Schedule s, [User] u, Course c , UserCourse uc
where s.CourseId = c.CourseId and u.UserId = uc.UserId and c.CourseId = uc.CourseId and u.UserId =@userId and s.Date>=@dateFrom and s.Date<=@dateEnd";

                    var command = _context.Database.GetDbConnection().CreateCommand();
                    command.CommandText = query;
                    command.Parameters.Add(new SqlParameter("@userId", userId));
                    command.Parameters.Add(new SqlParameter("@dateFrom", dateFrom));
                    command.Parameters.Add(new SqlParameter("@dateEnd", dateEnd));
                    _context.Database.OpenConnection();
                    var reader = command.ExecuteReader();
                    List<ScheduleDTO> schedules = new List<ScheduleDTO>();
                    while (reader.Read())
                    {
                        ScheduleDTO s = new ScheduleDTO();
                        s.ScheduleId = reader.GetInt32("ScheduleId");
                        s.Slot = reader.GetInt32("Slot");
                        s.Room = reader.GetString("Room");
                        s.CourseId = reader.GetInt32("CourseId");
                        schedules.Add(s);
                        
                    }
                    _context.Database.CloseConnection();
                    return Ok(schedules);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("get fail:" + ex.Message);
                throw;
            }
            
        }
    }
}
