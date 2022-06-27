using System.ComponentModel.DataAnnotations;

namespace UiniversityApiBackend.Models.DataModels
{
    public class Curso : BaseEntity
    {
        [Required, StringLength(100)]
        public string NameCourse { get; set; } = string.Empty;
        [StringLength(280)]
        public string? DescriptionShort { get; set; } = string.Empty;
        public string? DescriptionLong { get; set; } = string.Empty;
        [Required]
        public string PublicObjective { get; set; } = string.Empty;
        [Required]
        public string Objectives { get; set; } = string.Empty;
        [Required]
        public string Requirements { get; set; } = string.Empty;
        [EnumDataType(typeof(Level)),Required]
        public Level LevelAlumn { get; set; }
        public enum Level
        {
            Basic = 0,
            Intermediate = 1,
            Advance = 2
        }
    }
}
