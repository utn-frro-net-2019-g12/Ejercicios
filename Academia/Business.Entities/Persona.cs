using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    public class Persona : BusinessEntity {

        // public Persona() { }

        private int _Legajo;
        private TiposPersonas _TipoPersona;
        private string _Apellido;
        private string _Nombre;
        private string _Email;
        private DateTime _FechaNacimiento;
        private string _Direccion;
        private string _Telefono;
        private int _IDPlan;

        private int Legajo { get; set; }
        private TiposPersonas TipoPersona { get; set; }
        private string Apellido { get; set; }
        private string Nombre { get; set; }
        private string Email { get; set; }
        private DateTime FechaNacimiento { get; set; }
        private string Direccion { get; set; }
        private string Telefono { get; set; }
        private int IDPlan { get; set; }

        public enum TiposPersonas {
            Alumno,
            Profesor,
            Administrador
        }

    }
}
