using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Lab02 {
    class ManejadorArchivo {

        public ManejadorArchivo() {
            this.misContactos = this.getTabla();
        }

        protected DataTable misContactos;

        public virtual DataTable getTabla() {
            return new DataTable();
        }

        public virtual void aplicaCambios() { }

        public void listar() {
            foreach (DataRow fila in this.misContactos.Rows) {
                if (fila.RowState != DataRowState.Deleted) {
                    foreach (DataColumn col in this.misContactos.Columns) {
                        Console.WriteLine("{0} : {1}", col.ColumnName, fila[col]);
                    }
                    Console.WriteLine();
                }
            }
        }

        public void nuevaFila() {
            DataRow fila = this.misContactos.NewRow();
            foreach (DataColumn col in this.misContactos.Columns) {
                Console.Write("Ingrese {0}:", col.ColumnName);
                fila[col] = Console.ReadLine();
            }
            this.misContactos.Rows.Add(fila);
        }

        public void editarFila() {
            Console.Write("Ingrese el número de fila a editar: ");
            int nroFila = int.Parse(Console.ReadLine());
            DataRow fila = this.misContactos.Rows[nroFila-1];
            for (int nroCol = 1; nroCol < this.misContactos.Columns.Count; nroCol++) {
                // El 0 se Omite por ser el ID
                DataColumn col = this.misContactos.Columns[nroCol];
                Console.Write("Ingrese {0}:", col.ColumnName);
                fila[col] = Console.ReadLine();
            }
        }

        public void eliminarFila() {
            Console.Write("Ingrese el número de fila a eliminar: ");
            int nroFila = int.Parse(Console.ReadLine());
            this.misContactos.Rows[nroFila - 1].Delete();
        }

    }
}
