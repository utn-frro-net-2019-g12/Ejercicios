using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometria
{
    public class Triangulo
    {
        private double _lado1;
        private double _lado2;
        private double _lado3;

        public double Lado1
        {
            get => _lado1;
            set => _lado2 = value;
        }

        public double Lado2
        {
            get => _lado1;
            set => _lado2 = value;
        }

        public double Lado3
        {
            get => _lado1;
            set => _lado2 = value;
        }

        public double CalcularPerimetro()
        {
            return _lado1 + _lado2 + _lado3;
        }

        public double CalcularSuperficie()
        {
            // Superficie de Triángulo a partir de sus lados --> Fórmula de Herón
            double sp = (this.CalcularPerimetro() / 2); // sp es el "semiperímetro"
            return Math.Sqrt(sp * (sp - _lado1) * (sp - _lado2) * (sp - _lado3));
        }
    }
}
