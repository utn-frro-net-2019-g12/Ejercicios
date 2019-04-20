using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabClases5
{
    public class Jugada
    {

        private bool _adivino;
        private int _intentos;
        private int _numero;


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