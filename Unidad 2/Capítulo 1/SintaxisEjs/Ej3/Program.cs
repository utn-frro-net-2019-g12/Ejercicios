using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3
{
    // Hacer un programa para calcular la suma de la serie de Fibonacci.
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = 0, n2 = 1, n3, number, acum = n1 + n2;
            Console.Write("Número de Elementos: ");
            number = int.Parse(Console.ReadLine());
            Console.Write(n1 + " " + n2 + " ");
            for (int i = 2; i < number; i++)  
            {
                n3 = n1 + n2;
                acum += n3;
                Console.Write(n3 + " ");
                n1 = n2;
                n2 = n3;
            }
            Console.WriteLine();
            Console.WriteLine("Total: "+acum);
            Console.ReadKey();
        }
    }
}
