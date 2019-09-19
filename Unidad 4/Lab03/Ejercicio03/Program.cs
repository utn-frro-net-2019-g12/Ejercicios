using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio03 {
    class Program {
        static void Main(string[] args) {
            // DataSet "Tipado" con Designer: Instanciamos uno
            dsUniversidad miUniversidad = new dsUniversidad();

            // Un DataTable por Tabla en el Designer
            dsUniversidad.dtAlumnosDataTable dtAlumnos = new dsUniversidad.dtAlumnosDataTable();
            dsUniversidad.dtCursosDataTable dtCursos = new dsUniversidad.dtCursosDataTable();
            dsUniversidad.dtAlumnos_CursosDataTable dtAlumnos_Cursos = new dsUniversidad.dtAlumnos_CursosDataTable();

            // Agregar un Row para Alumnos
            dsUniversidad.dtAlumnosRow rowAlumno = dtAlumnos.NewdtAlumnosRow();
            rowAlumno.Apellido = "Pérez";
            rowAlumno.Nombre = "Juan";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);

            // Agregar un Row para Cursos
            dsUniversidad.dtCursosRow rowCurso = dtCursos.NewdtCursosRow();
            rowCurso.Curso = "Informatica";
            dtCursos.AdddtCursosRow(rowCurso);

            // Relaciones
            dsUniversidad.dtAlumnos_CursosRow rowAlumnos_Cursos = dtAlumnos_Cursos.NewdtAlumnos_CursosRow();
            dtAlumnos_Cursos.AdddtAlumnos_CursosRow(rowAlumno, rowCurso);

            // Otro Row para Alumnos
            rowAlumno = dtAlumnos.NewdtAlumnosRow();
            rowAlumno.Apellido = "Pérez";
            rowAlumno.Nombre = "Marcelo";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);

            dtAlumnos_Cursos.AdddtAlumnos_CursosRow(rowAlumno, rowCurso);

        }
    }
}
