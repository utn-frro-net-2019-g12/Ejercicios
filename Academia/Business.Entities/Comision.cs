using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    class Comision : BusinessEntity {

        // public Comision() { }

        private string _Descripcion;
        private int _IDPlan;
        private int _AnioEspecialidad;

        public string Descripcion { get; set; }
        public int IDPlan { get; set; }
        public int AnioEspecialidad { get; set; }

    }
}
