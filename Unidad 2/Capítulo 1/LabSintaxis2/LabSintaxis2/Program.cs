using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis2
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputTexto = "";
            Console.Write("Ingrese Texto: ");
            inputTexto = Console.ReadLine();
            Console.WriteLine();
            if (inputTexto != "")
            {
                Console.WriteLine("MENU DE OPCIONES");
                Console.WriteLine("1- Ver texto en mayúsculas");
                Console.WriteLine("2- Ver texto en minúsculas");
                Console.WriteLine("3- Ver longitud del texto");
                Console.WriteLine();
                Console.Write("Ingrese Número: ");
                ConsoleKeyInfo opcion = Console.ReadKey();
                Console.WriteLine();
                switch (opcion.Key)
                {

                    case (ConsoleKey.D1): Console.WriteLine(inputTexto.ToUpper()); break;
                    case (ConsoleKey.D2): Console.WriteLine(inputTexto.ToLower()); break;
                    case (ConsoleKey.D3): Console.WriteLine(inputTexto.Length); break;
                    default: Console.WriteLine("No se ha seleccionado Opción Disponible. Terminar"); break;


                }

            }
            else { Console.WriteLine("No se ha ingresado nada. Terminar"); }
            Console.ReadKey();

        }
    }
}

