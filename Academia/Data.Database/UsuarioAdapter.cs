using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database {
    public class UsuarioAdapter : Adapter {
        
        private static List<Usuario> _Usuarios;

        public static List<Usuario> Usuarios { get; set; }

        // Before DB
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private void oldListUsuarios() {
            /*
            private static List<Usuario> Usuarios { get {
                if (_Usuarios == null) {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
            */
        }
        #endregion

        public List<Usuario> GetAll() {
            // return new List<Usuario>();
            List<Usuario> usuarios = new List<Usuario>();
            try {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios", SqlConn);
                SqlDataReader drUsusarios = cmdUsuarios.ExecuteReader();
                while (drUsusarios.Read()) {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsusarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsusarios["nombre_usuario"];
                    usr.Clave = (string)drUsusarios["clave"];
                    usr.Habilitado = (bool)drUsusarios["habilitado"];
                    usr.Nombre = (string)drUsusarios["nombre"];
                    usr.Apellido = (string)drUsusarios["apellido"];
                    usr.Email = (string)drUsusarios["email"];
                    usuarios.Add(usr);
                }
                drUsusarios.Close();
            } catch (Exception ex) {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de usuarios", ex);
                throw ExcepcionManejada;
            } finally {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID) {
            // return Usuarios.Find(delegate (Usuario u) { return u.ID == ID; });
            Usuario usr = new Usuario();
            try {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario = @id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsusarios = cmdUsuarios.ExecuteReader();
                if (drUsusarios.Read()) {
                    usr.ID = (int)drUsusarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsusarios["nombre_usuario"];
                    usr.Clave = (string)drUsusarios["clave"];
                    usr.Habilitado = (bool)drUsusarios["habilitado"];
                    usr.Nombre = (string)drUsusarios["nombre"];
                    usr.Apellido = (string)drUsusarios["apellido"];
                    usr.Email = (string)drUsusarios["email"];
                }
                drUsusarios.Close();
            } catch (Exception ex) {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", ex);
                throw ExcepcionManejada;
            } finally {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(int ID) {
            // Usuarios.Remove(this.GetOne(ID));
            try {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            } catch (Exception ex) {
                Exception ExcepcionManejada = new Exception("Error al intentar eliminar usuario", ex);
                throw ExcepcionManejada;
            } finally {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario) {
            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, "+
                    "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email "+
                    "WHERE id_usuario=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();
            } catch (Exception ex) {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", ex);
                throw ExcepcionManejada;
            } finally {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario) {
            try {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO usuarios(nombre_usuario, clave, habilitado, nombre, apellido, email) " +
                    "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) " +
                    "SELECT @@identity", SqlConn); // @@identity es para recuperar el ID que SQL Server asignó automáticamente
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                // Así se obtiene el ID que asignó a la DB automáticamente
                cmdSave.ExecuteNonQuery();
            } catch (Exception ex) {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", ex);
                throw ExcepcionManejada;
            } finally {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario) {
            if (usuario.State == BusinessEntity.States.New) {
                /*
                int NextID = 0;
                foreach (Usuario usr in Usuarios) { if (usr.ID > NextID) { NextID = usr.ID; } }
                usuario.ID = NextID + 1;
                Usuarios.Add(usuario); 
                */
                this.Insert(usuario);
            } else if (usuario.State == BusinessEntity.States.Deleted) {
                this.Delete(usuario.ID);
            } else if (usuario.State == BusinessEntity.States.Modified) {
                // Usuarios[Usuarios.FindIndex(delegate (Usuario u) { return u.ID == usuario.ID; })] = usuario;
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }
        
    }
}
