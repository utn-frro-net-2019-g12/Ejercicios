using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej7
{
    // Calcular los N primeros números primos gemelos.
    class Program
    {
        static void Main(string[] args)
        {

            int num = 1, div, cant, counter = 0, twin=0;
            Boolean noPrimo, possib=false;

            Console.Write("Cantidad de parejas de Números Primos Gemelos a Mostrar: ");
            cant = int.Parse(Console.ReadLine());

            while (counter < cant) {
                div = 2; noPrimo = false;
                while ((div < num) & (noPrimo==false)) {
                    if (num % div == 0) { noPrimo = true; }
                    else { div++; }
                }
                if (noPrimo == false) {
                    if (possib & num==twin+2) {
                        Console.Write(twin + " " + num + " ");
                        num--;
                        counter++;
                        twin = 0;
                        possib = false;
                    }
                    else { twin = num; possib = true; }
                    
                }
                num++;
            }
            Console.ReadKey();
        }
    }
}
