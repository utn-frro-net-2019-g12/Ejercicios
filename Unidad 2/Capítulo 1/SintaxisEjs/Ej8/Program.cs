using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej8
{
    // Realizar un programa basado en el algoritmo (de la imagen del LAB) para el ingreso de una clave
    class Program
    {
        static void Main(string[] args)
        {
            string clave = "puntonet19", test = "";
            int maxIntentos = 4, actIntento = 0;
            Boolean passed = false;

            Console.WriteLine("SISTEMA DE SEGURIDAD");
            while (passed == false)
            {
                Console.WriteLine();
                if (actIntento < maxIntentos)
                {
                    actIntento++;
                    Console.Write("Introduzca la Clave: ");
                    test = Console.ReadLine();
                    if (test == clave) { passed = true; }
                    else { Console.WriteLine("Contraseña Incorrecta. Pruebe Nuevamente."); }
                } else { break; }
            }
            Console.WriteLine();
            if (passed == true) { Console.WriteLine("Contraseña Correcta!!!"); }
            else { Console.WriteLine("Se ha alcanzado el límite de intentos. Pruebe Más Tarde."); }
            Console.ReadKey();
        }
    }
}
