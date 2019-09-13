using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities {
    public class DocenteCurso : BusinessEntity {

        // public DocenteCurso() { }

        private int _IDCurso;
        private int _IDDocente;
        private TiposCargos _Cargo;

        private int IDCurso { get; set; }
        private int IDDocente { get; set; }
        private TiposCargos TipoPersona { get; set; }

        public enum TiposCargos {
            Titular,
            Ayudante,
            Suplente
        }

    }
}
