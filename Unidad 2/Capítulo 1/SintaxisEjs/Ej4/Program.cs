using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4
{
    // Construir una aplicación que proporcione todos los números pares entre el 1 y el 100.
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++) {
                if(i%2==0) { Console.Write(i+" "); }
            }
            Console.ReadKey();

        }
    }
}
