using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej9
{
    /*
    Crear uina aplicacion que pida un numero de filas y respecto a estas,
    dibuje un triangulo como el siguiente:

         *
        ***
       *****
      *******
     *********
    
    */

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese Cantidad de Filas: ");
            int cant, num = int.Parse(Console.ReadLine());
            int i,j,k;

            cant = (1 + (num - 1) * 2) / 2;
            for (i = 0; i < num; i++) {
                for (j = 0; j <= cant; j++) {
                    Console.Write(" ");
                }
                for (k = 1; k <= 1 + (2 * i); k++) { Console.Write("*"); }
                cant--;

                Console.WriteLine();
            }
            //1 3 5 7 9 11 13 15
            Console.ReadKey();
        }
    }
}
