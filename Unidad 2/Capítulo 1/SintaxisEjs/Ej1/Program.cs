using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{

    /*
     1)	Construir una aplicación que sume dos números y proporcione el resultado con el formato siguiente:
     El resultado de la suma de < número uno > y < número dos > es < resultado >.
     */

    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            Console.Write("Ingrese Número 1: ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Número 2: ");
            num2 = int.Parse(Console.ReadLine());

            int result = num1 + num2;
            Console.WriteLine("El resultado de la suma de " + num1 + " y " + num2 + " es: " + result);
            Console.ReadKey();
        }
    }
}

