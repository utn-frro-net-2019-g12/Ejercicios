using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ejercicio01 {
    class Program {
        static void Main(string[] args) {
            // Crear un DataTable de 2 Columnas, y cargar 2 Rows
            DataTable dtAlumnos = new DataTable("Alumnos");
            DataRow rwAlumno = dtAlumnos.NewRow();

            DataColumn colApellido = new DataColumn("Apellido", typeof(string));
            DataColumn colNombre = new DataColumn("Nombre", typeof(string));

            dtAlumnos.Columns.Add(colApellido);
            dtAlumnos.Columns.Add(colNombre);

            // rwAlumno[colApellido] = "Pérez";
            // rwAlumno[colNombre] = "Juan";
            rwAlumno["Apellido"] = "Pérez";
            rwAlumno["Nombre"] = "Juan";
            dtAlumnos.Rows.Add(rwAlumno);

            DataRow rwAlumno2 = dtAlumnos.NewRow();
            rwAlumno2["Apellido"] = "Pérez";
            rwAlumno2["Nombre"] = "Marcelo";
            dtAlumnos.Rows.Add(rwAlumno2);

            // Recorrer y exhibir Rows
            Console.WriteLine("Listado de Alumnos: ");
            foreach (DataRow row in dtAlumnos.Rows) {
                Console.WriteLine(row[colApellido].ToString() + ", " + row[colNombre].ToString());
            }
            Console.ReadKey();

        }
    }
}
