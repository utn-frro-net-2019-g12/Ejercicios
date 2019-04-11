using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej6
{
    // Dado un número entero, que se convierta a número romano.
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un Número entre 1 y 3999: ");
            int num = int.Parse(Console.ReadLine());
            int mil, cent, dec, uni, resto;
            String roman = "";

            mil = num / 1000;
            resto = num % 1000;
            cent = resto / 100;
            resto = resto % 100;
            dec = resto / 10;
            resto = resto % 10;
            uni = resto;

            switch (mil)
            {
                case 1: roman += "M"; break;
                case 2: roman += "MM"; break;
                case 3: roman += "MM"; break;
            }
            switch (cent)
            {
                case 1: roman += "C"; break;
                case 2: roman += "CC"; break;
                case 3: roman += "CC"; break;
                case 4: roman += "CD"; break;
                case 5: roman += "D"; break;
                case 6: roman += "DC"; break;
                case 7: roman += "DCC"; break;
                case 8: roman += "DCCC"; break;
                case 9: roman += "CM"; break;
            }
            switch (dec)
            {
                case 1: roman += "X"; break;
                case 2: roman += "XX"; break;
                case 3: roman += "XXX"; break;
                case 4: roman += "XL"; break;
                case 5: roman += "L"; break;
                case 6: roman += "LX"; break;
                case 7: roman += "LXX"; break;
                case 8: roman += "LXXX"; break;
                case 9: roman += "XC"; break;
            }
            switch (uni)
            {
                case 1: roman += "I"; break;
                case 2: roman += "II"; break;
                case 3: roman += "III"; break;
                case 4: roman += "IV"; break;
                case 5: roman += "V"; break;
                case 6: roman += "VI"; break;
                case 7: roman += "VII"; break;
                case 8: roman += "VIII"; break;
                case 9: roman += "IX"; break;
            }

            if (num>=4000)
            {
                roman = "Te fuiste del límite que mi paciencia podía desarrollar";
            }

            Console.WriteLine("Número en Romano: " + roman);
            Console.ReadKey();
        }
    }
}
