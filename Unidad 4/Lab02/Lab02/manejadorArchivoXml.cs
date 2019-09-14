using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Lab02 {
    class ManejadorArchivoXml : ManejadorArchivo {

        protected DataSet ds;

        public override DataTable getTabla() {
            this.ds = new DataSet();
            this.ds.ReadXml("agendaxml.xml");
            return this.ds.Tables["contactos"];
        }

        public override void aplicaCambios() {
            this.ds.WriteXml("agendaxml.xml");
            this.ds.WriteXml("agendaxmlconschema.xml", XmlWriteMode.WriteSchema);
        }

    }
}
