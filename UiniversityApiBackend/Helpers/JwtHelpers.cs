using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UiniversityApiBackend.Models.DataModels;

namespace UiniversityApiBackend.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            /*El claim lo que te da 
             es información sobre el usuario
            y por eso le pasamos el Identificador Global unico
            a esta funcion como parametro Id
            y un UserTokens que contiene toda la informacion del usuario con ese token */

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id", userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };

            /*Lo que etsamos genrando con los ifs son los roles que 
             va a tener en la API con el JSONWebtoken los usuarios*/

            if (userAccounts.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            } else if (userAccounts.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            /*Esta funcion lo que hace es que nos genra un nuevo id mediante 
             el GUid que es un Identificador GLobal Unico y que se lo pasa a la funcion de arriba*/
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }

        public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();
                if (model== null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                // Obtain SECRET KEY
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);

                Guid Id;

                // The Secret Token expires in 1 Day

                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // Validity of our token secret 

                userToken.Validity = expireTime.TimeOfDay;

                // Generate OUR JWT secret token 

                var jwToken = new JwtSecurityToken(
                        issuer: jwtSettings.ValidIssuer,
                        audience: jwtSettings.ValidAudience,
                        claims: GetClaims(model, out Id),
                        notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                        /*Lo que le estamos diciendo es que el token 
                         no va a expirar antes de ahora mismo cuando lo 
                        estamos generando*/
                        expires: new DateTimeOffset(expireTime).DateTime,
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256
                            /*El HmacSHA256 es el sistema 
                             de cifrado de la informacion 
                            por lo que todo el token va a ir 
                            cifrado*/
                            )
                    );

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);

                /*Dentro de nuestra clase de userToken
                 lo que tendremo sera todo el token
                cifrado con una cadena de texto hasheada*/

                userToken.Token = model.UserName;

                userToken.UserName = model.UserName;

                userToken.Id = model.Id;

                userToken.GuidId = Id;

                return userToken;
            } catch(Exception ex)
            {
                throw new Exception("Error Generating the JWT ", ex);
            }
        }
    }
}
