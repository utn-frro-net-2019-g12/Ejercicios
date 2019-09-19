using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ejercicio05 {
    class Program {
        static void Main(string[] args) {
            // Crear un objeto SQL Connection
            SqlConnection myConn = new SqlConnection();
            // myConn.ConnectionString = "Data Source=LOCALHOST;Initial Catalog=Northwind;User ID=sa;Pwd=123";
            myConn.ConnectionString = "Data Source=LOCALHOST;Initial Catalog=Northwind;Trusted_Connection=True;";

            // Crear un objeto DataTable llamado Empresas
            DataTable dtEmpresas = new DataTable("Empresas");

            // Agregar DataColumns
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            // Crear Adaptador (SQLDataAdapter) e indicarle el Command Text a utilizar en la consulta
            // También indicamos el StringConnection
            SqlDataAdapter myAdapter = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myConn);

            // Abrir Conexión
            myConn.Open();

            // Cargo el contenido del ResultSet obtenido de la base de datos en el objeto DataTable
            myAdapter.Fill(dtEmpresas);

            // Cierro la conexión
            myConn.Close();

            // Recorro la lista de empresas obtenidas y lo muestro en consola
            Console.WriteLine("Listado de Empresas: ");
            foreach (DataRow rowEmpresa in dtEmpresas.Rows) {
                string idEmpresa = rowEmpresa["CustomerID"].ToString();
                string nombreEmpresa = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine(idEmpresa + " - " + nombreEmpresa);
            }
            Console.ReadKey();

        }
    }
}
