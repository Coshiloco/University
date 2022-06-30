using System.ComponentModel.DataAnnotations;

namespace UiniversityApiBackend.Models.DataModels
{
    public class Category: BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        /*Para relacionarlo tambien con la tabla cursos lo que tenemso que hacer
         a su vez es qui generar una lista epro esta de vez de la tabla cursos*/
        [Required]
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
