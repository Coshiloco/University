// 1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UiniversityApiBackend;
using UiniversityApiBackend.DataAccess;
using UiniversityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

//2. Connection with SQL Server Express

const string CONNECTIONNAME = "UniversityDb";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//3. Add context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

//7. Add Service of JWT Autorization
builder.Services.AddJwtTokenServices(builder.Configuration);

// TODO : Connection with SQL Server Express





// Add services to the container.

builder.Services.AddControllers();

//4. Add Custom Services(folder Services)

builder.Services.AddScoped<IStudentService, StudentsService>();

// TODO : Add the rest of services

//8. Add Authorization

builder.Services.AddAuthorization(options =>
{
    /*Van a estar asociadas a un CLaim concreto es decir un Usuario en concreto*/
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 9. COnfig Swagger to take care of Autorization of JWT
builder.Services.AddSwaggerGen( options =>
{
    // We define the Security for authorization
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        // Para documentar Swagger de mejor forma con el JWT
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header using Bearer Scheme"
    });

    /*COn esto el Swagger lo que deberia 
     es solicitarnos un Bearer token cunado intentamos acceder a ciertar rutas protegidas*/
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

//5. CORS Configuration

/*El CORS define quienes pueden realizar peticiones a nuestra API,
 desde que entornos,
  que tipo de metodos pueden utilizar,
   y tambien que tipo de cabeceras pueden enviar en las peticiones a nuestra API*/

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//6. Tell app yo use CORS

app.UseCors("CorsPolicy");

app.Run();
