using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantIt = 5;
            String[] arr = new string[cantIt];

            Console.WriteLine("Ingrese 5 Líneas de Texto: ");
            for (int i = 0; i < cantIt; i++) {
                arr[i] = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine("Orden Invertido: ");
            for (int i = cantIt-1; i >=0 ; i--) {
                Console.WriteLine(arr[i]);
            }

            Console.ReadKey();

        }
    }
}
