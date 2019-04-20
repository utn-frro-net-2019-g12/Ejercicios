using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabClases6
{
    public class Jugada
    {

        protected bool _adivino;
        protected int _intentos;
        protected int _numero;

        /*protected para que las clases heredadas puedan ver dichos atributos*/

        public Jugada(int maxNumero)
        {
            Random rnd = new Random();
            _numero = rnd.Next(maxNumero);
            _adivino = false;
        }

        public bool Adivino
        {
            get
            {
                return _adivino;
            }
            set
            {
                _adivino = Adivino;
            }
        }

        public int Intentos
        {
            get
            {
                return _intentos;
            }
            set
            {
                _intentos = Intentos;
            }
        }

        public int Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                _numero = Numero;
            }
        }

        public void Comparar(int n)
        {
            if (n == _numero)
            {
                _adivino = true;
            }
            _intentos++;
        }

    }

}