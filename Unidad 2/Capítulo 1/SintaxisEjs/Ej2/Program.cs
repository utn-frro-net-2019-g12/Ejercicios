using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    // Crear una aplicacion que te pida un año y verifique si el año es bisiesto o no.
    class Program
    {
        static void Main(string[] args)
        {
            int year;
            Console.Write("Ingrese un Año: ");
            year = int.Parse(Console.ReadLine());
            if (year % 4 == 0) {
                if (year % 100 == 0) {
                    if (year % 400 ==0) {
                        Console.WriteLine("Ese Año es bisiesto");
                    } else { Console.WriteLine("Ese Año NO es bisiesto"); }
                } else { Console.WriteLine("Ese Año es bisiesto"); }
            } else { Console.WriteLine("Ese Año NO es bisiesto"); }
            Console.ReadKey();
        }
    }
}
