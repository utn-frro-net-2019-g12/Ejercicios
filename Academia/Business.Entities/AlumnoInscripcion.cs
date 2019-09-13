using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    class AlumnoInscripcion : BusinessEntity {

        // public AlumnoInscripcion() { }

        private int _IDAlumno;
        private int _IDCurso;
        private string _Condicion;
        private int _Nota;

        public int IDAlumno { get; set; }
        public int IDCurso { get; set; }
        public string Condicion { get; set; }
        public int Nota { get; set; }

    }
}
