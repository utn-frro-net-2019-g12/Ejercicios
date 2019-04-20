using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabClases6
{
    public class JugadaConAyuda : Jugada
    {

        public JugadaConAyuda(int maxNumero) : base(maxNumero)
        {

        }

        public new void Comparar(int n)
        {
            if (n == Numero)
            {
                _adivino = true;
            }
            else
            {
                int dist = Numero - n;
                if (Math.Abs(dist) < 5)
                {
                    Console.WriteLine("Estas a menos de 5 números de adivinarlo, ya casi!");
                }
                else if (Math.Abs(dist) < 20)
                {
                    Console.WriteLine("Estas a menos de 20 números, te estás acercando");
                }
                else if (Math.Abs(dist) < 50)
                {
                    Console.WriteLine("50 números distan de poder adivinarlo");
                }
                else
                {
                    Console.WriteLine("A más de 50 números... estás muy lejos de ganar");
                }

                if (dist > 0)
                {
                    Console.WriteLine("el número buscado es mayor");
                }
                else
                {
                    Console.WriteLine("el número buscado es menor");
                }

            }
            _intentos++;
        }
    }
}