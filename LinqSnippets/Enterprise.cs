using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Enterprise
    {
        // Atributos que luego nos van a servir para buscar obviamente atributos de la clase
        public int Id { get; set; }
        public string? Name { get; set; }
        public Employee[] Employees { get; set; } = new Employee[0];
    }
}
