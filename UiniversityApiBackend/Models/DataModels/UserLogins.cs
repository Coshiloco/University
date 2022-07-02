using System.ComponentModel.DataAnnotations;

namespace UiniversityApiBackend.Models.DataModels
{
    public class UserLogins
    {
        /*Esta clase nos va a servir para establecer el modelo 
         de login del usuario 
        es decir los campos que va a tener que rellenar*/
        
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
