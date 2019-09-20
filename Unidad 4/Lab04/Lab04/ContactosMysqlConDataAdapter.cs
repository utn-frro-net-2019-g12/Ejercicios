using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Lab04 {
    class ContactosMysqlConDataAdapter : Contactos {
        private string _connectionString = "Server=localhost;Database=net;Uid=root;Pwd=reptile;";
        private MySqlDataAdapter _adapter;

        protected string connectionString {
            get { return _connectionString; }
        }

        public MySqlDataAdapter adapter { get; set; }

        public ContactosMysqlConDataAdapter() : base() {
            this.adapter.InsertCommand = new MySqlCommand(
                "insert into contactos values(@id,@nombre,@apellido,@email,@telefono)");
            this.adapter.InsertCommand.Parameters.Add("@id", MySqlDbType.Int32, 1, "id");
            this.adapter.InsertCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 20, "nombre");
            this.adapter.InsertCommand.Parameters.Add("@apellido", MySqlDbType.VarChar, 20, "apellido");
            this.adapter.InsertCommand.Parameters.Add("@email", MySqlDbType.VarChar, 50, "email");
            this.adapter.InsertCommand.Parameters.Add("@telefono", MySqlDbType.VarChar, 10, "telefono");

            this.adapter.UpdateCommand = new MySqlCommand(
                "update contactos set nombre=@nombre, apellido=@apellido, email=@email,telefono=@telefono " +
                " where id=@id");
            this.adapter.UpdateCommand.Parameters.Add("@id", MySqlDbType.Int32, 1, "id");
            this.adapter.UpdateCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 20, "nombre");
            this.adapter.UpdateCommand.Parameters.Add("@apellido", MySqlDbType.VarChar, 20, "apellido");
            this.adapter.UpdateCommand.Parameters.Add("@email", MySqlDbType.VarChar, 50, "email");
            this.adapter.UpdateCommand.Parameters.Add("@telefono", MySqlDbType.VarChar, 10, "telefono");

            this.adapter.DeleteCommand = new MySqlCommand("delete from contactos where id=@id");
            this.adapter.DeleteCommand.Parameters.Add("@id", MySqlDbType.Int32, 1, "id");
        }

        public override DataTable getTabla() {
            this.adapter = new MySqlDataAdapter("select * from contactos", this.connectionString);
            DataTable contactos = new DataTable();
            this.adapter.Fill(contactos);
            return contactos;
        }

        public override void aplicaCambios() {
            using (MySqlConnection Conn = new MySqlConnection(this.connectionString)) {
                this.adapter.InsertCommand.Connection = Conn;
                this.adapter.UpdateCommand.Connection = Conn;
                this.adapter.DeleteCommand.Connection = Conn;
                this.adapter.Update(this.misContactos);
            }
        }

    }
}
