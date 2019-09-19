using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Ejercicio02 {
    class Program {
        static void Main(string[] args) {
            // Hay que mover los DataRows debajo de la declaración de Columns, y agreamos Columna ID
            DataTable dtAlumnos = new DataTable("Alumnos");

            DataColumn colIDAlumno = new DataColumn("IDAlumno", typeof(int));
            colIDAlumno.ReadOnly = true; // Indicamos Solo Lectura
            colIDAlumno.AutoIncrement = true; // Indicamos Autoincremental
            colIDAlumno.AutoIncrementSeed = 0; // El primer ID será 0
            colIDAlumno.AutoIncrementStep = 1; // Se incrementará de a 1
            DataColumn colApellido = new DataColumn("Apellido", typeof(string));
            DataColumn colNombre = new DataColumn("Nombre", typeof(string));

            dtAlumnos.Columns.Add(colApellido);
            dtAlumnos.Columns.Add(colNombre);
            dtAlumnos.Columns.Add(colIDAlumno);

            // Establezemos la Clave Primaria (PK)
            dtAlumnos.PrimaryKey = new DataColumn[] { colIDAlumno };

            DataRow rwAlumno = dtAlumnos.NewRow();
            rwAlumno["Apellido"] = "Pérez";
            rwAlumno["Nombre"] = "Juan";
            dtAlumnos.Rows.Add(rwAlumno);

            DataRow rwAlumno2 = dtAlumnos.NewRow();
            rwAlumno2["Apellido"] = "Pérez";
            rwAlumno2["Nombre"] = "Marcelo";
            dtAlumnos.Rows.Add(rwAlumno2);

            // Hacemos una segunda DataTable
            DataTable dtCursos = new DataTable("Cursos");
            DataColumn colIDCurso = new DataColumn("IDCurso", typeof(int));
            colIDCurso.ReadOnly = true;
            colIDCurso.AutoIncrement = true;
            colIDCurso.AutoIncrementSeed = 1;
            colIDCurso.AutoIncrementStep = 1;
            DataColumn colCurso = new DataColumn("Curso", typeof(string));
            dtCursos.Columns.Add(colCurso);
            dtCursos.Columns.Add(colIDCurso);
            dtCursos.PrimaryKey = new DataColumn[] { colIDCurso };

            // Le cargamos un Row
            DataRow rwCurso = dtCursos.NewRow();
            rwCurso["Curso"] = "Informatica";
            dtCursos.Rows.Add(rwCurso);

            // Ahora hacer un DataSet y agregarle los DataTables de arriba
            DataSet dsUniversidad = new DataSet();
            dsUniversidad.Tables.Add(dtAlumnos);
            dsUniversidad.Tables.Add(dtCursos);

            // Hacemos una DataTable con la relación N a N entre Alumnos y Cursos, y la agregamos al DataSet
            DataTable dtAlumnos_Cursos = new DataTable("Alumnos_Cursos");
            DataColumn col_ac_IDalumno = new DataColumn("IDAlumno", typeof(int));
            DataColumn col_ac_IDcurso = new DataColumn("IDCurso", typeof(int));
            dtAlumnos_Cursos.Columns.Add(col_ac_IDalumno);
            dtAlumnos_Cursos.Columns.Add(col_ac_IDcurso);

            dsUniversidad.Tables.Add(dtAlumnos_Cursos);

            // Agregamos Relaciones entre las Tablas
            DataRelation relAlumno_ac = new DataRelation("Alumno_AC", colIDAlumno, col_ac_IDalumno);
            DataRelation relCurso_ac = new DataRelation("Curso_AC", colIDCurso, col_ac_IDcurso);

            dsUniversidad.Relations.Add(relAlumno_ac);
            dsUniversidad.Relations.Add(relCurso_ac);

            // Agregamos Rows a la tabla intermedia
            DataRow rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[col_ac_IDalumno] = 0; // Alumno: Juan Pérez
            rwAlumnosCursos[col_ac_IDcurso] = 1; // Curso: Informatica
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);

            rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[col_ac_IDalumno] = 1; // Alumno: Marcelo Pérez
            rwAlumnosCursos[col_ac_IDcurso] = 1; // Curso: Informatica
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);

            // Ahora Exhibiremos los Alumnos que estén relacionados con un curso a seleccionar
            Console.Write("Por favor ingrese el nombre del curso: "); // Informatica
            string materia = Console.ReadLine();
            materia = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(materia.ToLower()); // Capitalización Palabra (Globalization)
            Console.WriteLine("Listado de Alumnos del curso " + materia + ":");
            DataRow[] row_cursoSelect = dtCursos.Select("Curso = '" + materia + "'");
            foreach (DataRow rowCu in row_cursoSelect) {
                DataRow[] row_alumnosCursoSelect = rowCu.GetChildRows(relCurso_ac);
                foreach (DataRow rowAl in row_alumnosCursoSelect) {
                    Console.WriteLine(
                        rowAl.GetParentRow(relAlumno_ac)[colApellido].ToString()
                        + ", " +
                        rowAl.GetParentRow(relAlumno_ac)[colNombre].ToString()
                    );
                }
            }
            Console.ReadKey();

        }
    }
}
