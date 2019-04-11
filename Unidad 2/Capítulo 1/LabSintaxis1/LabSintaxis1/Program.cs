using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis1
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputTexto = "";
            Console.Write("Ingrese Texto: ");
            inputTexto = Console.ReadLine();
            Console.WriteLine();
            if (inputTexto != "") {
                Console.WriteLine("MENU DE OPCIONES");
                Console.WriteLine("1- Ver texto en mayúsculas");
                Console.WriteLine("2- Ver texto en minúsculas");
                Console.WriteLine("3- Ver longitud del texto");
                Console.WriteLine();
                Console.Write("Ingrese Número: ");
                ConsoleKeyInfo opcion = Console.ReadKey();
                Console.WriteLine();
                if (opcion.Key == ConsoleKey.D1) {
                    Console.WriteLine(inputTexto.ToUpper());
                } else {
                    if (opcion.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine(inputTexto.ToLower());
                    }
                    else {
                        if(opcion.Key == ConsoleKey.D3) {
                            Console.WriteLine(inputTexto.Length);
                        } else {
                            Console.WriteLine("No se ha seleccionado Opción Disponible. Terminar");
                        }
                    }
                }
            } else Console.WriteLine("No se ha ingresado nada. Terminar");
            Console.ReadKey();

        }
    }
}
