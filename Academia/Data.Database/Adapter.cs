using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter {
        // Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal"; // For Net3 User, Write "ConnStringLocal3"

        // private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        private SqlConnection sqlConn;

        protected SqlConnection SqlConn { get; set; }

        protected void OpenConnection() {
            string connectionStringSettings = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            SqlConn = new SqlConnection(connectionStringSettings);
            SqlConn.Open();
        }

        protected void CloseConnection() {
            SqlConn.Close();
            SqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText) {
            throw new Exception("Metodo no implementado");
        }
    }
}
