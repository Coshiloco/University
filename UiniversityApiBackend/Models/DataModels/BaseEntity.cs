/*Esta tabla va a tener todos los campos comunes que queremos
 que tengan todas nuestras tablas*/

// Para establecer como va a ser el modelos de los datos
/*Es decir como van a ser los modelos d ela tabla
 osea person los campos de la tabla si obligatorios
de tipo string un Schema en otros lenguajes o formas
de trabajar */

using System.ComponentModel.DataAnnotations;

namespace UiniversityApiBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        /*El campo CreatedBy no acpeta valores null
         porque no es la id que hace referencia
        al nombre de la key
        por lo que le ponemos por defecto que el valor
        este vacio
        con el ? si queremos que ese campo sea 
        opcional*/
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
