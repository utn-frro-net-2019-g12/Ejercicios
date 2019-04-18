using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

/*
 Construir una aplicación que cumpla con los requisitos siguientes:

1)	Declarar una clase “Persona” que contenga la información siguiente de una persona:
•	Nombre
•	Apellido
•	Edad
•	DNI

2)	Implementar los métodos y propiedades siguientes:
•	Un constructor que reciba la información necesaria para iniciar la instancia y que proporcione un mensaje que indique la creación del objeto.
•	Un destructor que proporcione un mensaje que indique la destrucción del objeto.
•	Las propiedades correspondientes para acceder a cada uno de los atributos de la clase.
•	Un método GetFullName, el cual debe devolver la concatenación del nombre y apellido.
•	Un método GetAge, para calcular la edad de la persona.
*/

namespace Principal {
    class Principal {
        static void Main(string[] args) {
            var per = new Persona("Nico","Antonelli",21,"40905168");
            Console.WriteLine(per.getFullName());
            Console.WriteLine(per.getAge());
            Console.ReadKey();
            // Antes de cerrarse, se exhibe el destructor

        }
    }
}
