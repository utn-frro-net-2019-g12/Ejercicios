using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    public class Curso : BusinessEntity {

        // public Curso() { }

        private int _IDComision;
        private int _IDMateria;
        private string _Descripcion;
        private int _AnioCalendario;
        private int _Cupo;

        public int IDComision { get; set; }
        public int IDMateria { get; set; }
        public string Descripcion { get; set; }
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }

    }
}
