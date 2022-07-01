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
            
            List<int> numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
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
            int[] otherNumebrs = { 0, 2, 6};

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
    }
}