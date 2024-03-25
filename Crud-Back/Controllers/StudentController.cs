using Crud_Back.Data;
using Crud_Back.Models;
using Crud_Back.Repository;
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
        private readonly IStudentRepository _studentRepository;
        public StudentController(CrudDbContext contex, IStudentRepository studentRepository)
        {
            _context = contex;
            _studentRepository = studentRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _studentRepository.GetAllStudents();
            return Ok(students);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedStudent = await _studentRepository.AddStudent(student);
            return Ok(addedStudent);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, Student updateStudent)
        {
            var updatedStudent = await _studentRepository.UpdateStudent(id, updateStudent);
            if (updatedStudent == null)
            {
                return NotFound();
            }
            return Ok(updatedStudent);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var deletedStudent = await _studentRepository.DeleteStudent(id);
            if (deletedStudent == null)
            {
                return NotFound();
            }
            return Ok(deletedStudent);
        }
    }
}
