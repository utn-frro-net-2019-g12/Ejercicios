using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Console; --> Es tipo, no Namespace

namespace Clases
{
    public class A
    {
        private String NombreInstancia;

        // Constructors
        public A() {
            this.NombreInstancia = "Instancia sin Nombre";
        }

        public A(string nombre)
        {
            this.NombreInstancia = nombre;
        }

        public string MostrarNombre()
        {
            return this.NombreInstancia;
        }

        public string M1()
        {
            return "Método M1 Invocado";
        }
        public string M2()
        {
            return "Método M2 Invocado";
        }
        public string M3()
        {
            return "Método M3 Invocado";
        }

    }
}
