using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabClases6
{
    public class Juego
    {
        private int _record = int.MaxValue;

        public Juego()
        {
        }

        public void ComenzarJuego()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a >> Adivina el Número <<");
            Console.WriteLine("--------------------------------");
            int max = PreguntarMaximo();
            JugadaConAyuda jugada = new JugadaConAyuda(max);
            Console.WriteLine("Excelente, presione una tecla para comenzar a jugar");
            Console.ReadKey();
            Console.Clear();
            while (!jugada.Adivino)
            {
                Console.WriteLine();
                Console.WriteLine("Intento número << " + (jugada.Intentos + 1) + " >>");
                int n = PreguntarNumero();
                jugada.Comparar(n);
                if (!jugada.Adivino)
                {
                    Console.WriteLine("Ups, número equivocado, intente nuevamente");
                }
            }
            CompararRecord(jugada.Intentos);
            Console.WriteLine("¡Has adivinado! El número era: " + jugada.Numero);
            Console.WriteLine("Record de menor intentos: " + _record);
            Continuar();
        }

        private void CompararRecord(int n)
        {
            if (n < _record)
            {
                _record = n;
            }
        }

        private void Continuar()
        {
            Console.WriteLine("¿Desea continuar jugando? y/n");
            string op = Console.ReadLine();
            if (op.ToLower() == "y")
            {
                ComenzarJuego();
            }
        }

        private int PreguntarMaximo()
        {
            Console.WriteLine("Por favor, indique el número máximo a adivinar:");
            int max = int.Parse(Console.ReadLine());
            return max;
        }

        private int PreguntarNumero()
        {
            Console.WriteLine("Intente adivinar el número:");
            int n = int.Parse(Console.ReadLine());
            return n;
        }
    }
}