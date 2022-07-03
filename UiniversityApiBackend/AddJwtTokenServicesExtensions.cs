using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UiniversityApiBackend.Models.DataModels;

namespace UiniversityApiBackend
{
    public static class AddJwtTokenServicesExtensions
    {
        public static void AddJwtTokenServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            // Add o añadir JWT Settings
            var bindJwtSettings = new JwtSettings();

            /*Tenemos que configurar ahora la clave que pusimos en nuestro archivo appsettings.json*/

            Configuration.Bind("JsonWebTokenKeys", bindJwtSettings);

            // Add Singleton of JWT Settings
            Services.AddSingleton(bindJwtSettings);

            Services
                .AddAuthentication( options =>
                {
                    //Definimso que la Autenticacion va a ser de tipo JwtBearer
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    // Para comprobar los usuarios
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer( options =>
                {
                    // Las opciones que se van a configurar del token
                    options.RequireHttpsMetadata = false;
                    // Si queremos que se guarde el token
                    options.SaveToken = true;
                    /*Ahora vamos a configurar los parametros para que 
                     un token sea valido y lo vamos a coger del archivo appsettings.json*/
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigningKey,
                        /*Tenemos ahora que generar la firma del token pero tenemos que 
                         codificarla con Encoding y vamos a utilizar la que hemos configurado en 
                        */
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
                        ValidateIssuer = bindJwtSettings.ValidateIssuer,
                        ValidIssuer = bindJwtSettings.ValidIssuer,
                        ValidateAudience = bindJwtSettings.ValidateAudience,
                        ValidAudience = bindJwtSettings.ValidAudience,
                        RequireExpirationTime = bindJwtSettings.RequireExpirationTime,
                        ValidateLifetime = bindJwtSettings.ValidateLifetime,
                        // El ClockSkew es para que cuando se valide aplique un tiempo de validacion
                        ClockSkew = TimeSpan.FromDays(1)
                    };
                });
        }
    }
}
