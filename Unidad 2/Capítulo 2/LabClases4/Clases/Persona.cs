using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases {
    public class Persona {

        // Atributos
        private string _nombre;
        private string _apellido;
        private int _edad;
        private string _dni;

        // Constructor
        public Persona(string nombre, string apellido, int edad, string dni) {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            DNI = dni;
            Console.WriteLine("Persona Registrada!");
        }

        // Destructor
         ~Persona() {
            Console.WriteLine("Persona Eliminada!");
            Console.ReadKey();
        }

        // Propiedades (Getters and Setters)
        public string Nombre {
            get => _nombre;
            set => _nombre = value;
        }
        
        public string Apellido {
            get => _apellido;
            set => _apellido = value;
        }

        public int Edad {
            get => _edad;
            set => _edad = value;
        }

        public string DNI {
            get => _dni;
            set => _dni = value;
        }

        // Otros Métodos
        public string getFullName() {
            return Apellido + ", " + Nombre;
        }

        public int getAge() {
            // string fecha = DateTime.Now.ToString("M/d/yyyy");
            // Iba a hacer un cálculo comparando fecha de hoy y cumpleaños, pero ya tengo la edad!!!
            return Edad;
        }
    }
}