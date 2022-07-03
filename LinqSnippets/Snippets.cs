//Librerias que necesitamos
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        //Hacemos la funcion basica para buscar cosas
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audio A3",
                "Audio A5",
                "Fiat Punto",
                "Sear Ibiza",
                "Seat León"
            };

            //1. SELECT * of cars para hacer una consulta de todos los datos de todos los coches (SELECT ALL CARS)

            var carlist = from car in cars select car;

            // Arriba estamos utilizado una setencia SQL pero al Reves empezando por el from in select

            foreach (var car in carlist)
            {
                Console.WriteLine(car);
            }

            //2. SELECT WHERE es decir un select con condicionales como pro ejemplo que solo queremos los cohes que tengan Audi

            var audioList = from car in cars where car.Contains("Audi") select car;

            // Aqui solo tenemos la lista de los coches que tienen Audi

            foreach (var audi in audioList)
            {
                Console.WriteLine(audi);
            }

            /*car tiene muchos metodos con lo que se peuden hacer muchas clausulas 
             para filtrar busquedas*/

        }

        // Ejemplos con Nuemros 
        static public void LinqNumbers()
        {
            //Vamos a trabajar ahora ocn listas de nuemros

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            /*Las operaciones que vamos ha hacer son 
             MUltiplicar cada numero por tres | Each Number multiplied by 3
            Obtener todos los nuemros menos el 9 | take all numbers but 9
            Ordenar todos los numeros de forma ascendente | ORder numbers by ascending value*/

            var processedNumberList = numbers
                .Select(num => num * 3) // Al seleccionarlos los multiplicamos por 3 directamente
                .Where(num => num != 9) // all but 9 | cojemos todos menos el 9 es decir los que sean distintos de 9
                .OrderBy(num => num); // at the end we order by ascend | los ordenamos de forma ascendente
        }
        // Busquedas avanzadas
        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            //1. Search first of all elements encontrar el primero de los elementos

            var first = textList.First();

            //2. First element that is "c" | Coger el primer elemento que contenga al letra c

            var FirstCLetterInTextList = textList.First(text => text.Equals("c"));

            // CUando ponemos el => estamos diciendo que e suna funcion anonima es

            // COmo un callback en JavaScript o TypeScript

            /*Entonces lo que le estamos diciendo es una vez encuentres el primero
             me pasas la variable me la guardas en la variabel text dentro de los paraentesis
            y ejecuto un callback o segunda funcion que me compare
            si esa letra alamacenada en la variabel text sea igual a la letra c*/

            //3.  First element that contains "j" | es decir el primer elemento que contenga la palabra j

            var FirstJLetterInTextList = textList.First(text => text.Contains("j"));

            //4. First element that contains  Z or default value | Priemr elemento que contenga la Z o valor por defecto

            var FirstZOrDefault = textList.FirstOrDefault(text => text.Contains("z")); // Default " or first element that Contains "Z

            // Si no encuentra la Z lo que te devulve es una cadena de texto vacia

            //5. Last element that contains  Z or default value | Ultimo elemento que contenga la Z o valor por defecto

            var LastZOrDefault = textList.LastOrDefault(text => text.Contains("z")); // Default " or last element that Contains "Z"

            // 6. SIngle Values or Valores Unicos

            var uniqueTexts = textList.Single();

            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            // Working this metods at the top with number trabajamos con los metodos pero ahora con numeros en vez
            // De con cadenas

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherNumebrs = { 0, 2, 6 };

            // Queremos obtener los nuemros que  no estan repetitdos

            var noRepetNumbers = evenNumbers.Except(otherNumebrs); // Return {4, 8}

        }

        // Select mas complejos con multiples cluasulas de condicion 

        static public void MUltipleSelect()
        {
            // SELECT MANY

            string[] myOpninios =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            /*LO que hacemos es coger la lista y la separamos por comas pero como ya hemos visto
             antes lo que hacemos es un callback o funcino que nos permita dentro de cada opinion
            que estamos cogiendo seperarla por comas*/

            var MyOpinionSlection = myOpninios.SelectMany(opinion => opinion.Split(","));

            // Create a enterprises List

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enetrprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Martin",
                            Email = "martin@pelotas.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Pepe",
                            Email = "pepe@pelotas.com",
                            Salary = 1000
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Juanjo",
                            Email = "juanjo@pelotas.com",
                            Salary = 2000
                        },
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enetrprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "ana@pelotas.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Maria",
                            Email = "maria@pelotas.com",
                            Salary = 1500
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Marta",
                            Email = "marta@pelotas.com",
                            Salary = 4000
                        },
                    }
                }
            };

            //Ahora ya estamos trabajando con objetos 

            // Obtain all employees of all Enterprises
            // OBtener todos los trabajadores de todas las empresas que en este caso son dos

            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            //Nos sale un warning advirtiendonos de que lo que podemos obtener son valores nulos

            // Know if anylist can be Empty | Es decir comprobar si la lista esta vacia

            bool hasEnterprises = enterprises.Any(); // if hasEnterprises? return True Otherwise False

            // Know if anyEnterprises has Employees

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any()); // if hasEmployees? return True Otherwise False

            /*Hacemos el callback porque primero mira si hay empresas y una vez dentro nos devuelve
             la empresa y una vez devuelta con la funcion de callback lo que hace
            es comprobar si dentro de esa empresa se encuentra el atributo de Employees
            y si no esta vacia o no*/

            // All enterprises at least has employees with at least 1000€ of salary

            bool hasEmployeeWithSalaryMoreThan1000 =
                enterprises.Any(enterprise =>
                    enterprise.Employees.Any(employee => employee.Salary >= 1000));

        }

        // Para trabajar con colecciones

        static public void linqCollections()
        {
            var firstlist = new List<string>() { "a", "b", "c" };

            var secondlist = new List<string>() { "a", "c", "d" };

            // INNER JOIN

            var CommonReuslt = from element in firstlist
                               join secondElement in secondlist
                               on element equals secondElement
                               select new { element, secondElement };
            /*Lo que esta haciendo el inner join buscar en las dos listas
             es decir primer elemento de la primera lista primer elemento de la segunda lista 
            entonces con el on estableces una condicion tan solo cuando
            sean iguales estos dos elementos me generas una nueva lista con los elementos compartidos*/

            // Segunda forma de hacer un INNER JOIN con funcion 

            /*Aclarar que un INNER JOIN lo que busca son los patrones comunes que se encuentran
             en dos listas o mas para juntarlo y extraer un resultado*/

            var CommonReuslt2 = firstlist.Join(
                    secondlist, // Lista con la que se va unir para bsucar patrones
                    element => element, // Nos guarda aqui el primer elemento de la primera lista
                    secondElement => secondElement, // Nos guarda aqui el segundo elemento de la segunda lista
                    (element, SecondElement) => new { element, SecondElement }
                    /*Lo que hacemos ahi es coger los dos elementos ya previamente guardados 
                     se los pasamos como parametro a la otra funcion 
                    y cuando se los pasamos nos genera un nuevo array 
                    con los parametros iguales*/
                );

            // OUTER JOIN - LEFT 

            /*Es decir encontrar los elementos que se queden fueran de cierta condicion fuera
             de la tabla izqueirda*/

            var leftOuterJoin = from element in firstlist
                                join secondElement in secondlist
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            /*Vale lo que hacemos es coger los elementos de la primera lista
             cogemos los elementos de la segunda lista guardamos en un array
            temporal es decir que ese array temporal lo que va a guardar son los mismos
            elementos de los dos listas en este caso a y c luego lo guardo 
            en la lista temporal una vez guardado en la lista temporal 
            la recorremos le ponemos un check por el que si esta vacia nos devulve un valor por defecto
            entonces comprobamos que el elemento de la primera lista no es igual al que esta en la lista
            temporal para que asi nos guarde en la primera lista los que son distintos
            por lo que en la nueva lista guardamos el elemento que se esta comparando en la 
            nueva lista*/

            // Otra manera de hacer el  OUTER JOIN - LEFT 

            var leftOuterJoin2 = from element in firstlist
                                 from secondElement in secondlist.Where(secondElement => secondElement == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };


            /*DefaultIfEmpty si no es null te retorna la secuencia especifica por lo que esteria retornando
             la segunda lista pero previamente ya hemos hecho la comprobacion de coger los comunes por 
            lo que ahorramos*/


            // OUTER JOIN - RIGHT

            var rightOuterJoin = from secondElement in secondlist
                                 join element in firstlist
                                 on secondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };

            /*Vale lo que hacemos es coger los elementos de la segunda lista
             cogemos los elementos de la segunda lista guardamos en un array
            temporal es decir que ese array temporal lo que va a guardar son los mismos
            elementos de los dos listas en este caso a y c luego lo guardo 
            en la lista temporal una vez guardado en la lista temporal 
            la recorremos le ponemos un check por el que si esta vacia nos devulve un valor por defecto
            entonces comprobamos que el elemento de la segunda lista no es igual al que esta en la lista
            temporal para que asi nos guarde en la segunda lista los que son distintos
            por lo que en la nueva lista guardamos el elemento que se esta comparando en la 
            nueva lista*/

            // UNION o union de listas es decir juntas las dos listas sin mas que estan almacenadas en nuestras variables
            var unionList = leftOuterJoin.Union(rightOuterJoin);

            /*Es decir que esta cogiendo los dos elementos no comunes de las dos listas y las esta uniondo
             permitiendo asi que no haya reprtidos que era nuestro objetivo*/

        }
        // Funcion qu enos permite saltarnos elementos mas avanzada
        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            // Nos vamos a saltar lso dos primeros elementos SKIP TWO FIRST VALUES

            var skipTwoFirstValues = myList.Skip(2); // {3,4,5,6,7,8,9,10} == output

            var skipLastTwoValues = myList.SkipLast(2); // {1,2,3,4,5,6,7,8} == output

            /*SkipWhile itera sobre skipLastTwoValues entonces lo que hace es que se salta es decir 
             los skipea los que son menores que 4 no los toma en consideracion*/

            var SkipWhileSmallerThan4 = myList.SkipWhile(nubersList => nubersList < 4); // {4, 5,6,7,8} == output

            // Take para tomar los valores

            var TakeTwoFirstValues = myList.Take(2); // {1,2} == output

            var TakeLastTwoValues = myList.TakeLast(2); // {9,10} == output

            var TakeWhileSmallerThan4 = myList.TakeWhile(nubersList => nubersList < 4); // {1,2,3} == output
        }

        // Paging es deicr que para luego posteriormente con el front hace una pequeña tabla que se pagina de 10 en 10 o lo que sea

        // With Skip and Take dentro de una misma linea

        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {

            /*Es decir Imaginemos que nos dice el page number 2 pues lo restamos 
             y lo multplicamos por el intervalo de paginacion que nosotros hemos decidido*/

            int startIndex = (pageNumber - 1) * resultsPerPage;

            /*Luego Hacemos el SKIP del startIndex porque no nos interesa
             y cogemos en la coleccion el intervalod e paginacion que nosotros le hemos marcado*/

            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquare = Math.Pow(number, 2)
                               where nSquare > average
                               select number;

            /*Las variables de tipo let que se encuentran dentro de esa consulta 
             solo viven en la consulta por tanto se podrian considerar variables de ambito local
            la spodemos hacer en toda la consulta por lo tanto lo que estamos haciendo
            es recorrernos la lista de numeros almacenar en una variable local de la consulta con la palabra
            reservada de tipo let la media o average
            y con otra variable lo que estamos haciendo es guardar el cuadrado del numero 
            de la lista que estamos recorriendo o seleccionando imitando una consulta 
            sql con NSquare 
            luego con el where establcecemos la condicion como si de 
            sql se tratase y seleccionamos con el select aquellos que su raiz sea mayor que la media*/

            // Tambien podemos imprimir la media

            Console.WriteLine("Average {0} : ", numbers.Average());

            // POdemos reocrrenos los valores devueltos por la consulta SQL que hemos hecho arriba con la variable aboveAverage

            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Query: Number {0} Square {1}", number, Math.Pow(number, 2));
            }

        }

        // ZIP

        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNubers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);

            /*OutPut de la impresion de arriba 
             {"1=one", "2=two" ...}
            Es decir que lo hacemos es guardar en una variable de tipo
            coleccion la lista empaquetada 
            Por tanto para que haya un Zip para que podamos ejecutar esa funcion tiene que tener las dos listas el mismo
            numero de parametros
            por tanto lo que hace el ZIP le pasamos
            priemro la lista de los string porque va a ser de tipo string nuestra coleccion y luego recibe en un
            callback o funcion de retorno los numeros de numbers que es la lista que ejecuta la funcion y la palabra
            del primer parametro y el resultado de ese callback hace que nos genere la nueva coleccion
            con el formato que tiene el callback ene l cuerpo de nuestra fufncion de callback*/
        }

        // Repeat & Range

        static public void RepeatRangeLinq()
        {
            //Generate collection from 1 - 1000

            IEnumerable<int> first1000 = Enumerable.Range(1, 1000); // Generate a inetegral squence of numbers first start number second count

            var QueryLinQ = from number in first1000
                            select number;

            // Repeat a value N times N represent a number of time that we dont know at this moment

            IEnumerable<string> fiveXs = Enumerable.Repeat("x", 5); // output XXXXX {X,X,X,X,X}

            // First parametre represent the data to repetir
            // Secind parameter represent the time that it doing the repetition


        }

        static public void studentsLinq()
        {
            // Creamos la lista de estudiantes para hacer las consultas avanzadas

            var classrom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martin",
                    Grade = 80,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true
                },
                new Student
                {
                    Id = 4,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true
                }

            };

            // Obtener los estudiantes que estan certificados

            var certifiedStudents = from student in classrom
                                    where student.Certified == true
                                    select student;
            //No certificados

            var notCertified = from student in classrom
                               where student.Certified == false
                               select student;

            // alumnos aprobadoe sesta va a ser con el && para que la selct te coja el segundo parametro

            var approvedStudentsNames = from student in classrom
                                   where student.Grade >= 50 && student.Certified == true
                                   select student.Name;
        
        }

        // All

        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };

            bool allAresmallerThan10 = numbers.All(x => x < 10); //output true

            /*Lo que le estamos diciendo es guardar en una variable un booleano
             que nos coge el ALL y el callback o funcion nos devulve cada elemento y 
            hacemos que la condicion sea menor que 10*/

            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); // output false

            var emptyList = new List<int>();

            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true output
        }

        // Aggregate 

        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Sum all numbers 

            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            /*Output
             0 + 1 => 1,
             1 + 2 => 3
             3 + 4 => 7
             7 + 5 => 12
             12 + 6 => 18*/

            /*La funcion Aggregate funciona como un acumulador lo que le pasamos a la funcion 
             es una funcion de callback que tiene dos parametros uno que es la suma previa es decir
            el primero es 0 y el valor actual es por el que se 
            recorre la coleccion el cual sera 1 por lo que en la siguiente iteracion 
            lo que hace es el que el valor prevSum de la funcion callback que se ejecuta dentro del 
            Aggregate toma el valor de la suma y el valor current sigue recorriendo la coleccion
            por lo que ahora valdra 2 y asi continuamente es decir es como si tuvieramos una variable 
            auxiliar haciendonos la suma*/

            string[] words = { "hello,", "my", "name", "is", "Martin" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);

            /*Output
             " " + "hello," => hello,
            "hello," + "my" => hello, my
            "hello, my" + "name" => hello, my name*/

            /*Esta funcion hace lo mismo que la anetrior opero como estamos operando con mas al hacer el acomulador
             lo que hace es que te concatena las cadenas de texto o lo que es lo mismo 
            las sumas*/
        
         }

        //Disctinct

        static public void distinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9 };
            IEnumerable<int> values = numbers.Distinct();

            /*Lo que hace la funcion perse es coger y 
             generarnos una lista qco nlos valores que no estan repetidos en la lista original
             pero a esta funcion tambien se le puede 
            meter un callback dentro de los parenteis del DIstint como condicion 
            que tenga que cumplir */
        }

        // Group BY

        static public void groupByExamples()
        {
            List<int> numbers = new List<int>() { 1,2,3,4,5,6,7,8,9 };

            // Vamos a aobtener dos grupos de nuemros los que cumplen
            // Cierta condicion y los que no 

            var grouped = numbers.GroupBy(x => x % 2 == 0);

            /* Se supone que tiene que dar dos grupos
             el priemro es todos aquellos numeros de la coleccion
            que cumplen con el requisito 
            y la otra es aquella condicion que no cumple la condicion*/

            /*POr tanto para recorrenos la collecion 
             tenemos que hacer dos bucles foreach*/

            foreach (var group in grouped) { 
                foreach (var value in group)
                {
                    Console.WriteLine(value);
                    /*Se supoen que esto nos tendria que imprimir 
                     primero los valores que no cumplen la condicion
                     del GroupBy de ser nuemros pares definida esa 
                    condicion por la funcion flecha o callback que se encuentra 
                    entre los parentesis
                    y luego nos devulve los valores que 
                    cumplen dicha restriccion 
                    por tanto la secuencia de salida por consola seria 
                    1,3,5,7,9 ... 2,4,6,8*/
                }
            }

            // Tambien podemos hacerlo con objetos
            
            var classrom = new[]
           {
                new Student
                {
                    Id = 1,
                    Name = "Martin",
                    Grade = 80,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true
                },
                new Student
                {
                    Id = 4,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true
                }

            };

            // Podmeos hacer un Group bay por la gente que ha aprobado

            var CertifiedQueryStudent = classrom.GroupBy(student => student.Certified == true);

            /*Obtenemos dos resultados en la consulta por el GroupBy
             
             1. Los que no estan certificados
            
             2. Los que estan certificados*/

            // Para recorrernos la consulta generada por el GroupBy necesitamos el foreach

            foreach (var group in CertifiedQueryStudent)
            {
                Console.WriteLine("--------  {0}  ---", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }

            /*Es decir que el GroupBy lo que esta tirando son dos listas 
             la primera una lista asociada de tipso booleanos 
            que esta asociada a la condicion que tenemos en el callback 
            dentro de los parenteis del GroupBY
            y otra Lista que son los esstudiantes es decir cada objeto estudiante
            */

        }

        //Relacion de tablas

        static public void relationsLinq ()
        {
            // Hacemis una lista de Posts

            List<Post> posts = new List<Post> ()
            {
                new Post()
                {
                    Id = 1,
                    Title = "My first post",
                    Content = "My first content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id=1,
                            Created = DateTime.Now,
                            Title = "My first comment",
                            Content = "My content"
                        },
                        new Comment()
                        {
                            Id=2,
                            Created = DateTime.Now,
                            Title = "My second comment",
                            Content = "My other content"
                        }
                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "My second post",
                    Content = "My second content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id=3,
                            Created = DateTime.Now,
                            Title = "My other comment",
                            Content = "My new content"
                        },
                        new Comment()
                        {
                            Id=4,
                            Created = DateTime.Now,
                            Title = "My other new comment",
                            Content = "My new content"
                        }
                    }
                }
            };

#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            var COntentofPosts = posts.SelectMany(
                post => post.Comments, 
                (post, comment) => new { PostID = post.Id, CommentContent = comment.Content  });
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo

            /* Lo que estamos seleccionando es todos y lo que nos esta
             sacando es una funcion de callback en el que obtenemos 
            es un post por orden y luego de ese post rcibimso con la coma 
            otra funcion en el que tiene dos parametros ese callback que es el post
            en si y la lista de comments es decir cada comentario y generamos una 
            nueva lista que sea el ID del Post y el Content que tenga ese post*/

        }
    }
}