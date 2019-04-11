using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{

    /*
    Construir una aplicación que reciba el nombre de un mes del año como el parámetro y proporcione su número correspondiente.
    Debe ser con el formato: < Nombre del mes > + < número del mes >.
    */

    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            String mes = "";
            Console.Write("Escriba un nombre de Mes: ");
            mes = Console.ReadLine().ToLower();

            switch(mes)
            {
                case "enero": num = 1; break;
                case "febrero": num = 2; break;
                case "marzo": num = 3; break;
                case "abril": num = 4; break;
                case "mayo": num = 5; break;
                case "junio": num = 6; break;
                case "julio": num = 7; break;
                case "agosto": num = 8; break;
                case "septiembre": num = 9; break;
                case "octubre": num = 10; break;
                case "noviembre": num = 11; break;
                case "diciembre": num = 12; break;
                default: num = 0; break;
            }
            Console.WriteLine();
            if (num != 0)
            {
                Console.WriteLine(mes + " " + num);
            } else
            {
                Console.WriteLine("Ese Mes no existe");
            }
            Console.ReadKey();
        }
    }
}
