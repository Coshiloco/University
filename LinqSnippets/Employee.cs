using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Employee
    {
        // Los campos que va a tener el empleado que obviamente son atributos de esta clase
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Salary { get; set; }
        public string? Email { get; set; }
    }
}
