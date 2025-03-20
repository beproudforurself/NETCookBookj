using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsTestAPI1._1.Models;

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
        public async Task<ActionResult<IEnumerable<student>>> Getstudents()
        {
            return await _Context.students.ToListAsync();
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
