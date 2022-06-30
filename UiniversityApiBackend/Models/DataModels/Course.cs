using System.ComponentModel.DataAnnotations;

namespace UiniversityApiBackend.Models.DataModels
{
    public enum Level
    {
        Basic,
        Medium,
        Hard,
        Expert
    }
    public class Course : BaseEntity
    {
        [Required, StringLength(100)]
        public string NameCourse { get; set; } = string.Empty;
        [StringLength(280)]
        public string? DescriptionShort { get; set; } = string.Empty;
        [Required]
        public string? DescriptionLong { get; set; } = string.Empty;
        [Required]
        public string PublicObjective { get; set; } = string.Empty;
        [Required]
        public string Objectives { get; set; } = string.Empty;
        [Required]
        public string Requirements { get; set; } = string.Empty;
        [Required]
        public Level Level { get; set; } = Level.Basic;
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        /*Esto es lo que nos lo va a asociar con la tabla de categorias
         con la lista es decir relacionamos la tabla cursos con la tabla categorias*/
        // Aparte de las categorias tendria que relacionarse con estudiantes para saber cuantos estan matriculados con una
        // Collection como ya hemos visto que nos sirve para relacionarlas
        // Ponemos el indice o Tabla Index para relacionarla con la tabla Index
        [Required]
        public Chapters Chapters { get; set; } = new Chapters();
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
