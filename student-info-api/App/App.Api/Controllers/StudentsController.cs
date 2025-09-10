using App.Api.Data;
using App.Api.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public StudentsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _dbContext.Students.ToListAsync();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentEntity student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_dbContext.Students.Any(s => s.Number == student.Number))
            {
                return Conflict("Bu numara zaten mevcut!");
            }
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentEntity model)
        {
            if (ModelState.IsValid is false) return BadRequest(ModelState);

            var student = await _dbContext.Students.FindAsync(id);
            if (student is null) return NotFound("Öğrenci bulunamadı!");
            if (model.Number != student.Number && _dbContext.Students.Any(s => s.Number == model.Number && s.Id != id))
            {
                return Conflict("Bu numara başka bir öğrenciye ait!");

            }
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Number = model.Number;
            student.Class = model.Class;
            await _dbContext.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student is null) return BadRequest();
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
