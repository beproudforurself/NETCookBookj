using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsTestAPI.Data;
using StudentsTestAPI.Models;
namespace StudentsTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _Context;

        public StudentsController(StudentContext Context )
        {
            _Context = Context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Getstudents()
        {
            return await _Context.Students.ToListAsync();
        }

    }
}
