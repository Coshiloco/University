using System.ComponentModel.DataAnnotations;
namespace UiniversityApiBackend.Models.DataModels
{
    public class Student: BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        /*Es decir que este estudiante puede estar en N cursos matriculado*/
    }
}
