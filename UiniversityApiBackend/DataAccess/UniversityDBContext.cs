// TIene que heredar de Entityframwork con la palabra reservada using

using Microsoft.EntityFrameworkCore;
using UiniversityApiBackend.Models.DataModels;

namespace UiniversityApiBackend.DataAccess
{
        // Se hereda dentro de la clase con los dos puntos
        /* El DbContext es una clase 
         de entity framwork que repsenta la conexion de la base de datos
        y que representa el modelo para construir con codigo las tablas de la abse de datos
        y demas 
        */
    public class UniversityDBContext: DbContext
    {
        // Hacemos el constructor 
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)
        {

        }

        // TODO: Add DbSets (Tables of our DB)
        /*Aqui se añaden las tablas
         para que al geenrar la migracion
        se generen las tablas en base
        a nuestros modelos*/
        /*Le estamos diciendo con DbSet
         que nos genere un modelo en base a nuestra clase
        Users
        ? con el interrogante le decimos por si
        acaso si existe o no para
        que no nos salte un error
        Luego el nombre como queremos que se llame 
        la tabla Users y los get y set entre los parentesis*/
        public DbSet<User>? Users { get; set; }

        /*El contexto es como un marco donde
         estamos haciendo todas nuestra instancias
        que son como una caja donde se encuentran todas
        las entidades o tablas con el DBSet que 
        genera nuestro modelo traducido de nuestra clase
        en programacion de Users*/

        /*Añadimso la tabla de curso que hereda directamente
         de la de identidad base por lo que tiene
        todos los campos especificos y ademas los suyos propios
        hemos comprobado que efectivamente se genera el 
        modelo de nuestra base de datos en el cotexto que es
        ese grafico donde se nos muestra
        de manera grafica las tablas y campos 
        que tiene nuestra base de datos*/
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        /*Importante cuando hacemos una public ICollection<Course> Courses { get; set; } = new List<Course>();
         en ambos campos de la tabla en el de cursos una lista 
        apuntando a categorias y en el de categorias una lista apuntando a cursos
        se nos crea como una tabla intermedia que tiene la id 
        de un curso y una categoria es decir dos campos uno que es CategoryID y otro que es
        COurseID que relacionan las dos tablas dado que un curso puede tner N categorias y una Categoria
        N cursos*/

        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapters>? Indexs { get; set; }

    }
}
