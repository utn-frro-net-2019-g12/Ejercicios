using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Circulo
    {
        private double _radio;

        public double Radio
        {
            get {
                return _radio; // default(int);
            }
            set {
                _radio = value;
            }
        }

        public double CalcularPerimetro()
        {
            return Math.PI * (Radio * 2);
            // throw new System.NotImplementedException();
        }

        public double CalcularSuperficie()
        {
            return Math.PI * (Radio * Radio);
            // throw new System.NotImplementedException();
        }
    }
}
