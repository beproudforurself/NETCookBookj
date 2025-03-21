using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsTestAPI1._1.Models;
using StudentsTestAPI1._1.Utils;

namespace StudentsTestAPI1._1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly databaseContext _Context;

        public EntityController(databaseContext Context)
        {
            _Context = Context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<student>>>> Getstudents()
        {
            try
            {
                var students = await _Context.students.ToListAsync();
                return Ok(ApiResponse<IEnumerable<student>>.ResponseSuccess(students, "get all students info success"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<IEnumerable<student>>.ResponseFailed($"get all students info failed: {ex.Message}", 500));
            }          
        }

        [HttpPost]
        public async Task<ActionResult<student>> PostStudent(student student )
        {
            _Context.students.Add(student);
            await _Context.SaveChangesAsync();

            return Ok();
        
        
        }

    }


}
