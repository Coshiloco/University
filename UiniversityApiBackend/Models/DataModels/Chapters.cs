using System.ComponentModel.DataAnnotations;

namespace UiniversityApiBackend.Models.DataModels
{
    public class Chapters: BaseEntity
    {
        // Relacion con la tabla curso
        public int CourseID { get; set; }
        public virtual Course Course { get; set; } = new Course();


        [Required]
        public string List = string.Empty;
    }
}
