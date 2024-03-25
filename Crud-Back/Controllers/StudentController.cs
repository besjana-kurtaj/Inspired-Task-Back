using Crud_Back.Data;
using Crud_Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CrudDbContext _context;
        public StudentController(CrudDbContext contex)
        {
            _context = contex;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllStudent()
        {
            var prod = await _context.Students.ToListAsync();
            return Ok(prod);

        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(student);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, Student updateStudent)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return BadRequest("Student not found");
            }
            student.FirstName =updateStudent.FirstName;
            student.LastName = updateStudent.LastName;
            student.DateOfBirth = updateStudent.DateOfBirth;
            student.Gender = updateStudent.Gender;

           
            await _context.SaveChangesAsync();
            return Ok(student);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }
    }
}
