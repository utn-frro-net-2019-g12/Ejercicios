using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    class Plan : BusinessEntity {

        // public Plan() { }

        private string _Descripcion;
        private int _IDEspecialidad;

        public string Descripcion { get; set; }
        public int IDEspecialidad { get; set; }

    }
}
