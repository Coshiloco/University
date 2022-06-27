using System.ComponentModel.DataAnnotations;

namespace UiniversityApiBackend.Models.DataModels
{
    /*Esta clase va a ser la tabla usuario que hereda
     de la de BAseENtity por tanto tendra todos los atributos
    de esa mas los que tenga esta clase*/
    public class User: BaseEntity
    {
        // Le estamos diciendo que el campo del USername
        // Es obligatorio y que no puede superar los 
        // 50 caracteres
        [Required, StringLength(50)]
        public string UserName { get; set; } = string.Empty;
        // Para establecer las restricciones extras
        // De otros caracteres 
        // tenenemos que poner otros corchetes
        [Required, StringLength(100)]
        public string Lastname { get; set; } = string.Empty;
        // La restriccion de EmailAddress lo que
        // contiene es el regex para validar
        // Un email
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
