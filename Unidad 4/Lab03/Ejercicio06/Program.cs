using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ejercicio06 {
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
            Console.WriteLine();

            // Indicar el Customer ID a Modificar
            Console.Write("Escriba el CustomerID que se desea modificar: ");
            string custID = Console.ReadLine();
            Console.WriteLine();


            // Me traigo una colección de DataRows que contengan ese CostumerID
            DataRow[] rwEmpresas = dtEmpresas.Select("CustomerID = '" + custID + "'");
            if (rwEmpresas.Length != 1) {
                // Si No Existe
                Console.WriteLine("CustomerID No Encontrado");
                Console.ReadKey();
                return; // Salida Prematura del Programa
            }

            // Me traigo el primer DataRow de la Colección
            DataRow rowMiEmpresa = rwEmpresas[0];
            string nombreActual = rowMiEmpresa["CompanyName"].ToString();

            // Muestro en la Consola el Nombre de la Compañía de este CustomerID
            Console.WriteLine("Nombre actual de la empresa: " + nombreActual);

            // Solicito que escriba un nuevo nombre
            Console.Write("Escriba un nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            // Llamo al método BeginEdit del DataRow para indicar los cambios
            rowMiEmpresa.BeginEdit();

            // Modifico el valor del campo CompanyName
            rowMiEmpresa["CompanyName"] = nuevoNombre;

            // Finalizo la edición llamando al método EndEdit
            rowMiEmpresa.EndEdit();

            // Ahora creo un objeto Command que será utilizado para guardar los cambios en la Base de Datos
            SqlCommand updCommand = new SqlCommand();

            // Le indico la Connection
            updCommand.Connection = myConn;

            // Le indico la cadena TSQL
            updCommand.CommandText = "UPDATE Customers SET CompanyName = @CompanyName WHERE CustomerID = @CustomerID";

            // Indico los parámetros a utilizar, como también: tipo y longitud del dato, nombre del campo del DataTable
            updCommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 50, "CompanyName");
            updCommand.Parameters.Add("@CustomerID", SqlDbType.NVarChar, 5, "CustomerID");

            // Ahora adjunto el objeto updCommand al DataApadter
            myAdapter.UpdateCommand = updCommand;

            // Por último, llamo al método .Update del DataAdapter
            myAdapter.Update(dtEmpresas);

            Console.WriteLine("CustomerID Modificado Correctamente!");
            Console.ReadKey();

        }
    }
}
