using Crud_Back.Models;

namespace Crud_Back.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(int id, Student updatedStudent);
        Task<Student> DeleteStudent(int id);
    }
}
