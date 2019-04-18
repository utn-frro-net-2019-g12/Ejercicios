using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometria {
    public abstract class Poligono {
        public abstract double CalcularPerimetro();
        public abstract double CalcularSuperficie();

    }

    public class Rectangulo : Poligono {

        private double _base;
        private double _altura;

        public double Base { get; set; }
        public double Altura { get; set; }

        public override double CalcularPerimetro() {
            return _base * 2 + _altura * 2;
        }
        public override double CalcularSuperficie() {
            return _base * _altura;
        }
 
    }

    public class Cuadrado : Rectangulo {

        private double _lado;

        public double Lado {
            get => _lado;
            set { _lado = base.Altura; }
        }

        public override double CalcularPerimetro() {
            return _lado * 4;
        }
        public override double CalcularSuperficie() {
            return _lado * _lado;
        }

    }

}
