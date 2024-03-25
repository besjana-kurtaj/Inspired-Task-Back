using Crud_Back.Data;
using Crud_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Back.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CrudDbContext _context;

        public StudentRepository(CrudDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var test= await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (test == null)
                return null;
            return test;
        }

        public async Task<Student> AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(int id, Student updatedStudent)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return null;
            }

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.DateOfBirth = updatedStudent.DateOfBirth;
            student.Gender = updatedStudent.Gender;

            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return null;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }
    }
}
