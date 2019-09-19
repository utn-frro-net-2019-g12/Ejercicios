using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ejercicio04 {
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

            // Crear un objeto SQL Command
            SqlCommand myComando = new SqlCommand();

            // Indicar la cadena TSQL que utilizará
            // TSQL = Transaction SQL, Extensión de SQL Server!
            myComando.CommandText = "SELECT CustomerID, CompanyName FROM Customers";

            // Indicar el objeto Connection que utilizará
            myComando.Connection = myConn;

            // Abrir Conexión
            myConn.Open();

            // Crear objeto DataReader, Ejecutar el método ExecuteReader del objeto myComando
            // SqlDataReader myDR = myComando.ExecuteReader();

            // Cargo los datos en el DataTable utilizando el objeto DataReader
            // dtEmpresas.Load(myDR);

            // O las anteriores 2 cosas, en una sola línea
            dtEmpresas.Load(myComando.ExecuteReader());

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
