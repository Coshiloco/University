// 1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using UiniversityApiBackend.DataAccess;
using UiniversityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

//2. Connection with SQL Server Express

const string CONNECTIONNAME = "UniversityDb";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//3. Add context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

//7. Add Service of JWT Autorization
// builder.Services.AddJwtTokenservices(builder.Configuration);

// TODO : Connection with SQL Server Express





// Add services to the container.

builder.Services.AddControllers();

//4. Add Custom Services(folder Services)

builder.Services.AddScoped<IStudentService, StudentsService>();

// TODO : Add the rest of services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 8. TODO: COnfig Swagger to take care of Autorization of JWT
builder.Services.AddSwaggerGen();

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
