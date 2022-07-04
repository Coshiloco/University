using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UiniversityApiBackend.DataAccess;
using UiniversityApiBackend.Helpers;
using UiniversityApiBackend.Models.DataModels;

namespace UiniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /*COmo siempre en los controles tenemos que generar una variable de tipo 
         readondly que nos va a guardar los jwtSettings*/

        // Necesitaremos tambien acceso al contexto de la universidad en geenral para tenr todas acceso
        // A todas las tabals en las que hayamos metido dentro de este context con un DBSet

        private readonly UniversityDBContext _context;

        private readonly JwtSettings _jwtSettings;

        /*El constructor que nos va ainicialziar las settings es decir 
         ese objeto de jwtSettings que le pasamos al constructor para que nos los guarde 
        en la variable readonly y
        asi podamos utilziarlo a lo largo de toda la clase*/

        public AccountController(UniversityDBContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        /*Vamos ha hacer una variable de clase o atributo que 
         le hardcodemos los datos a mano para su posterior implementacion 
        de la forma que se tiene que hacer*/

        // Exmaple USers
        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "mecomeslapolla@diosmio.com",
                UserName = "Admin",
                Password = "Admin"
            },

            new User()
            {
                Id = 2,
                Email = "probosionado@cagoendios.com",
                UserName = "User 1",
                Password = "pepe"
            }
        };

        /*Vamos a hacer una peticion de tipo post con los datos de la fucnion de arriba
         que nos simula la funcion de arriba */
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try {
                var Token = new UserTokens();
                /*Tenemos que comprobar ahora si un usuario es valido 
                 mediante el metodo de las consultas Linq con el any
                por tanto en la fuuncion de callback tenemos que ver que el usario que le estamos 
                recorriendo es igual al usuario que le estamos pasando en la fucnino es decir 
                si relamente se ha registraod*/

                // Tendriamos que buscar el Usuario como hace nuestro controler de Users

                var Valid = Logins.Any(user => user.UserName.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                /*StringComparison.OrdinalIgnoreCase esta funcion lo que hace es que en la compracion
                 no haga distincion entre mayusculas y minusculas*/

                // La condcion de comprobacion es verdadera a partir 
                // De esa de condicion generamos el JWT Token

                if (Valid)
                {
                    /*Aqui lo que estamos haciendo es decir una vez es valido es decir
                     una vez el usuario que me has pasado por esta funcion 
                    se encuentra en la base de datos tenemos que 
                    encontrar la primera ocurrencia del mismo para sacar sus datos y asi 
                    poder generar su JWT Token en la funcino de arriba de Logins porque 
                    es de prueba*/
                    var user = Logins.FirstOrDefault(user => user.UserName.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    /*Aqui ahora una vez encontrado el usario registrado 
                     tenemos que generar el Token con el HElper de la clase JwtHelper que nos creamos 
                    para modularizar y agilar el proceso y a esta le pasamos un objeto USertoken 
                    creada en nuestra carpeta DataModels*/

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = user.UserName,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid(),

                    }, _jwtSettings);
                } else
                {
                    return BadRequest("Wrong Credentials");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error ", ex);
            }
        }

        /*Aqui vamos a tener la peticion 
         para el rol de administrador es decir que solo aquellos usuarios con el rol
        de administradores podran acceder a la ruta */

        [HttpGet]
        // Linea de codigo que lo que hace es comprobar que el token generado tiene el rol de administrador para poder acceder a la ruta
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]

        /*Aqui la funcino que nos va a devolver el controlador lo que pasa es como estamos
         cogiendo la funcion Logins que esta hardcodeada con dos uarios 
        como ejemplo le decimos que nos devuelva esa funcion*/

        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }

    }
}
