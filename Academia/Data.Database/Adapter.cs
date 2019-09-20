using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter {
        // Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";

        // private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        private SqlConnection _sqlConn;

        protected SqlConnection sqlConn { get; set; }

        protected void OpenConnection() {
            string connectionStringSettings = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection(connectionStringSettings);
            sqlConn.Open();
        }

        protected void CloseConnection() {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText) {
            throw new Exception("Metodo no implementado");
        }
    }
}
