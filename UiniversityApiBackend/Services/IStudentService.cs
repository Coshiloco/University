using UiniversityApiBackend.Models.DataModels;

namespace UiniversityApiBackend.Services
{
    public interface IStudentService
    {
        //Sacar los estudiantes que tiene cursos
        IEnumerable<Student> GetStudentsWithCourses();
        // Los que no tienen cursos
        IEnumerable<Student> GetStudentsWithNoCourses();
    }
}
