using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;
// using System.Console; --> Es tipo, no Namespace

namespace LabClases1
{
    class Program
    {
        static void Main(string[] args)
        {
            A instA = new A();
            B instB = new B();

            // Los métodos de A pueden ser usados por B
            Console.WriteLine(instA.M1()); // Método 1
            Console.WriteLine(instB.M1()); // Método 1 Heredado
            Console.WriteLine(instB.MostrarNombre()); // Muestra "Instancia de B"

            Console.ReadKey();
        }
    }
}
